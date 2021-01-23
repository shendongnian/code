    public class Test : ConfigurationElement
    {
        [ConfigurationProperty("field", IsKey = true, Default="issuer", IsRequired=true)]
        [RegexStringValidator("issuer|subject")]
        public string Field
        {
            get { return (string)base["field"]; }
        }
    }
