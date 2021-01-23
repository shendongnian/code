    public class Provider
    {
        public Provider(object provider)
        {
            dynamic dynamicProvider = provider;
            this.FirstName = dynamicProvider.FirstName;
            this.LastName = dynamicProvider.LastName;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
