    // some classes to represent our settings
    public abstract class Parameter
    {
        public string Key { get; private set; }
        public Parameter( string key ) { this.Key = key; }
    }
    public class StringParameter : Parameter
    {
        public string Value { get; set; }
        public StringParameter( string key, string value ) : base( key )
        {
            this.Value = value;
        }
    }
