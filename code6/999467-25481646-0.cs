            public List<Category> Get_Categories()
        {
           
                using (var context = new ProcessDatabaseEntities())
                {
                    
                    //context.Configuration.LazyLoadingEnabled = false;
                    var list = context.Category.Include(p => p.MethodComponent).ToList();
                    return list;
                }
            
        }
