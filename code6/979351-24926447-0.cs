    public TObject Update(TObject entityObj, List<String> properties)
            {
    
                var entities = _context.Set<TObject>().Attach(entityObj);
                foreach (var property in properties)
                {
                    _context.Entry(entities).Property(property).IsModified = true;
                }
                _context.SaveChanges();
                return entityObj;
            }
