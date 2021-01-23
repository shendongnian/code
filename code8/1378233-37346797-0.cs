    // This also uses ICriteria, but adds some logic to auto-handle paths to reduce the number of paths needed to pass in to match how 
            // EntityFramework works e.g. if one path is passed in for OrderInputs.Input, this method will call SetFetchMode twice, once for OrderInputs and again for OrderInputs.Input
            public T GetByIdSetFetchModeEFStyle(Guid id, ISession session, params string[] includePaths)
            {   
                ICriteria criteria = session.CreateCriteria<T>();
    
                if (includePaths != null && includePaths.Length > 0)
                {
                    // NHibernate requires paths to be supplied in order.  So if a path "OrderInputs.Input" is supplied, we must make 
                    // 2 separate calls to SetFetchMode, the first with "OrderInputs", and the second with "OrderInputs.Input".
                    // EntityFramework handles this for us, but NHibernate requires things to be different.
                    List<string> pathsToUse = this.GetPathsToUse(includePaths);
    
                    foreach (string path in pathsToUse)
                    {
                        criteria.SetFetchMode(path, FetchMode.Eager);
                    }
                }
    
                return criteria
                    // prevent duplicates in the results
                    .SetResultTransformer(Transformers.DistinctRootEntity)
                    .Add(Restrictions.Eq(typeof(T).Name + "Id", id)).UniqueResult<T>();
            }
    
            private List<string> GetPathsToUse(string[] includePaths)
            {
                var nhPaths = new List<string>();
                foreach (string path in includePaths)
                {
                    if (!path.Contains(".") && !nhPaths.Contains(path))
                    {
                        // There is no dot in the path - just add it if it hasn't been added already
                        nhPaths.Add(path);
                    }
                    else
                    {
                        // We have a dot e.g. OrderInputs.Input.  We need to add "OrderInputs" before "OrderInputs.Input"
                        string[] pathParts = path.Split(".".ToCharArray());
    
                        // Add any missing ancestors of the current path prior to adding the path
                        for (int p = 1; p <= pathParts.Length; p++)
                        {
                            string requiredPath = string.Join(".", pathParts.Take(p).ToArray());
                            if (!nhPaths.Contains(requiredPath))
                            {
                                nhPaths.Add(requiredPath);
                            }
                        }
                    }
                }
                return nhPaths;
            }
