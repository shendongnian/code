    public bool Update(T persistableEntity)
            {
                if (persistableEntity != null)
                {
                    session.BeginTransaction();
                    session.Merge(persistableEntity);
                    session.Transaction.Commit();
                    return true;
                }
                return false;
            }
