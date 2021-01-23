            // i assume your service interfaces inherit from IService
            Assembly ass = typeof(ICodeTableService).GetTypeInfo().Assembly;
            // get all concrete types which implements IService
            var allServices = ass.GetTypes().Where(p =>
                p.GetTypeInfo().IsClass && 
                !p.GetTypeInfo().IsAbstract &&
                typeof(IService).IsAssignableFrom(p));
            foreach (var type in allServices)
            {           
                var allInterfaces = type.GetInterfaces();
                var mainInterfaces = allInterfaces.Except
                        (allInterfaces.SelectMany(t => t.GetInterfaces()));
                foreach(var itype in mainInterfaces)
                {
                    if (allServices.Any(x => !x.Equals(type) && itype.IsAssignableFrom(x)))
                    {
                        throw new Exception("The " + itype.Name + " type has more than one implementations, please change your filter");
                    }
                    services.AddScoped(itype, type);
                }
            } 
