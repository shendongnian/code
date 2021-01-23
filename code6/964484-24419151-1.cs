    public abstract class Provider
    {
        private readonly JsonMeta _providerMeta;
        protected Provider(TokenProfile profile, JsonMeta json)
        {
            // do stuff with JsonMeta object
        }
        protected abstract class JsonMeta { }
    }
    public class SalesforceProvider : Provider
    {
        public SalesforceProvider(TokenProfile profile)
            : base(profile, new SalesforceJson())
        { }
        private class SalesforceJson : JsonMeta
        {
            // Salesforce-specific stuff
        }
    }
