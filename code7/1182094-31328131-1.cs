    [TypeConverter(typeof(FooConverter))]
    [JsonConverter(typeof(NoTypeConverterJsonConverter<Foo>))]
    public class Foo
    {
        public bool a { get; set; }
        public bool b { get; set; }
        public bool c { get; set; }
        public Foo() { }
    }
    public class FooConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, System.Type sourceType)
        {
            if (sourceType == typeof(string))
            {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);
        }
        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value is string)
            {
                string s = value.ToString();
                //s = s.Replace("\\", "");
                Foo f = JsonConvert.DeserializeObject<Foo>(s);
                return f;
            }
            return base.ConvertFrom(context, culture, value);
        }
    }
