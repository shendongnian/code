            //using system.reflection
            String className = "mytestlibrary.my_class";
            String dllPath = "...mytestlibrary.dll";
            String methodName = "gethello";
            Assembly assembly = Assembly.LoadFile(dllPath);
            Type type = assembly.GetType(className);
            MethodInfo method = type.GetMethod(methodName);
            object context = Activator.CreateInstance(type);
            object[] parameters = new object[0];
            String result = (String) method.Invoke(context, parameters);
            //result is "hello world"
