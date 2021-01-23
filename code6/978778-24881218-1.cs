    public class JsonRegistration : IRegistrations
    {
        public IEnumerable<TypeRegistration> TypeRegistrations
        {
            get
            {
                yield return new TypeRegistration(typeof(JsonSerializer), typeof(CustomJsonSerializer));
            }
        }
    
        public IEnumerable<CollectionTypeRegistration> CollectionTypeRegistrations { get; protected set; }
        public IEnumerable<InstanceRegistration> InstanceRegistrations { get; protected set; }
    }
