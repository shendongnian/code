    public class MyObject
    {
    	[TypeConverter(typeof(IBANTypeConverter))]
    	public string IBAN { get; set; }
    }
