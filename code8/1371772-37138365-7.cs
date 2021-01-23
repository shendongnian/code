        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {         
            //other stuff.....
    
            Func<Type, bool> genericFilter = x => typeof(IEnumerable).IsAssignableFrom(x) && x.GenericTypeArguments.Length == 1;
    
            //All types of your context tables
            var tablesTypes = GetType().GetProperties()
                .Where(x => genericFilter(x.PropertyType))
                .Select(x => x.PropertyType.GenericTypeArguments.First());
    
            var namespaces2ignore = new List<string> { "Namespace2Ignore1", "Namespace2Ignore2" };
            var toIgnore = new List<Type>();
            foreach (var type in tablesTypes)
                //Ignore internal types, which not exist at tablesTypes
                toIgnore.AddRange(type.GetProperties()
                    .Select(x => genericFilter(x.PropertyType) ? x.PropertyType.GenericTypeArguments.First() : x.PropertyType)
                    .Where(x => !tablesTypes.Contains(x) && namespaces2ignore.Contains(x.Namespace)
                    /*or as you suggested: && typeof(A).Assembly == x.Assembly*/
                ).ToList());            
    
            modelBuilder.Ignore(toIgnore);
        }
