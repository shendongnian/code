    public class TranslateString : MarkupExtension
    {
        public string Value { get; set; }
    
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (String.IsNullOrWhiteSpace(Value))
                return Value;
            return Translation.getString(Value);
        }
    }
