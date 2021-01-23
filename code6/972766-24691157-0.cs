    public void Update(T entity, string[] columns)
            {
                if (columns != null)
                {
                    _dbset.Attach(entity);
                    foreach (var item in columns)
                    {
                        DataContext.Entry(entity).Property(item).IsModified = true;
                    }
                }
            }
