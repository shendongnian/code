    sealed class MyCustomBinder : SerializationBinder
    {
       public override Type BindToType(string assemblyName, string typeName)
       {
           var name = new AssemblyName(assemblyName);
           if (name.GetPublicKeyToken() == null) // Better check here...
           {
               var publicKeyToken = Assembly.GetExecutingAssembly()
                   .GetName().GetPublicKeyToken();
               name.SetPublicKeyToken(publicKeyToken);
           }
           // Now let's create required type using name and typeName
       }
       // Other code
    }
