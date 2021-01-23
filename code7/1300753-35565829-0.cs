    public class AllInterfacesConvention : StructureMap.Graph.IRegistrationConvention
    {
        public void ScanTypes(TypeSet types, Registry registry) 
        {
            foreach(Type type in types.FindTypes(TypeClassification.Concretes | TypeClassification.Closed)
            {
                foreach(Type interfaceType in type.GetInterfaces())
                {
                    registry.For(interfaceType).Use(type);
                }
            }
        }
    }
