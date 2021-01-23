    public class AutofacContractResolver : DefaultContractResolver
    {
        private readonly IContainer _container;
        public AutofacContractResolver(IContainer container)
        {
            _container = container;
        }
        protected override JsonObjectContract CreateObjectContract(Type objectType)
        {
            JsonObjectContract contract;
            // use Autofac to create types that have been registered with it
            if (_container.IsRegistered(objectType))
            {
                //get the class that is mapped to the interface from autofac
                Type mappedType = _container.GetMappedTypeForRegisteredType(objectType);
                //so for example when objectType now contains 'ICompany'
                //then mappedType now should contain 'Company'
                //now use the mappedType to create the contract
                contract = base.CreateObjectContract(mappedType);
                //but still use the objectType for resolving
                contract.DefaultCreator = () => _container.Resolve(objectType);
            }
            else
                contract = base.CreateObjectContract(objectType);
            return contract;
        }
    }
