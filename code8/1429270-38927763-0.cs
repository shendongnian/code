    public class FooEngineElement : EngineElement
    {
        [ConfigurationProperty("id", IsRequired = true)]
        public string Id
        {
            get { return (string) this["id"]; }
            set { this["id"] = value; }
        }
        public override IEngine Create()
        {
            return new FooEngine(Id);
        }
    }
