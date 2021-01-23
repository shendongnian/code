    ContractResolver : DefaultContractResolver
    {
         public override JsonContract ResolveContract(Type type)
         {
            //check if type is ObservableCollection
            if (type.GetTypeInfo().IsGenericType
                     && type.GetTypeInfo().GetGenericTypeDefinition() 
                              == typeof(ObservableCollection<>))
            {
                //use list as default contract
                var c = (JsonArrayContract) 
                          base.ResolveContract(typeof(List<>)
                              .MakeGenericType(type.GenericTypeArguments[0]));
                //use Activator to create instance
                c.DefaultCreator = () => Activator.CreateInstance(type);
                return c;
             }
             else return base.ResolveContract(type);
         }
    }
