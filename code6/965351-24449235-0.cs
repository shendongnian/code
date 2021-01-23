    public T InvokeFunction<T>(repositoryPerson function, params object[] parameters)
        {
            object instance = Activator.CreateInstance(typeof(RepositoryPerson));
            MethodInfo mi = instance.GetType().GetMethod(function.ToString());
            
            return (T)mi.Invoke(instance, parameters);
            
        }
