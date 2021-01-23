    public IQueryable<List<string>> GetApplicationNames()
        {
            using (ComData.Entities db = new ComData.Entities())
            {
                return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<List<string>>("GET_ALL_APPS").ToList().AsQueryable();
            }
        }
