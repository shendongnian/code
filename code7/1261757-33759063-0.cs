    Assembly assemblyInstance=Assembly.Load(dll);
    Type[] asseblyTypes=assemblyInstance.GetTypes();
    
    foreach(Type t in asseblyTypes)
    {
        if(t.fullName.Equals(name of class i want))
        {
            try to get the method info by t.GetMethod(name,type of parameter)
            and then do methodInfo.Invoke...
        }
    }
