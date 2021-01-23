    public void RegisterModels(IServiceCollection services, string[] Assemblies, string @NameSpace)
        {
            foreach (var a in Assemblies)
            {
                Assembly loadedAss = Assembly.Load(a);
                var q = from t in loadedAss.GetTypes()
                        where t.IsClass && !t.Name.Contains("<") && t.Namespace.EndsWith(@NameSpace)
                        select t;
                
                foreach (var t in q.ToList())
                {
                    Type.GetType(t.Name);
                    services.AddTransient(Type.GetType(t.FullName), Type.GetType(t.FullName));
                }
            }
        }
