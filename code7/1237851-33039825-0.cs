      object[] newobj = { pkey,entityType,pKyes };
                object[] parameters = new object[] { newobj };
                Type t = typeof (string);
                Type linqType = typeof (LinqDynamic<>);
                Type genericLinqType = linqType.MakeGenericType(entityType);
                object o = Activator.CreateInstance(genericLinqType, null);
                MethodInfo method = genericLinqType.GetMethod("GetEntityByPrimaryKey");
                var results = method.Invoke(o, parameters);
