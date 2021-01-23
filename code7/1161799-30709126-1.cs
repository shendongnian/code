    var instances = (from t in System.Reflection.Assembly.GetCallingAssembly().GetTypes()
                            where t.GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(ILabelData<>))
                                     && t.GetConstructor(Type.EmptyTypes) != null
                            select Activator.CreateInstance(t)).ToList();
            foreach (dynamic item in instances)
            {
                var res = item.GetData(1);
            }
