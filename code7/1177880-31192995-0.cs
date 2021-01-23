    [TypeConverter(typeof(PetTypeConverter))]
    public enum PetType
    {
        [Description("Kitty-cat")]Feline,
        [Description("doggie")]Canine,
        [Description("scary!")]Dragon,
        [Description("Extra-Terra")]Alien
    }
    class Pet
    {
        public string Name { get; set; }        
        public PetType Species { get; set; }
        public Pet(string name, PetType p)
        {
            Name = name;
            Species = p;
        }
    }
    public class PetTypeConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext 
                context, Type destinationType)
        {
            if (object.ReferenceEquals(destinationType, typeof(string)))
            {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }
          
        public override object ConvertTo(ITypeDescriptorContext context, 
                CultureInfo culture, object value, Type destinationType)
        {
	        if (object.ReferenceEquals(destinationType, typeof(string))) {
	        	FieldInfo fi = value.GetType().GetField(value.ToString());
	        	DescriptionAttribute[] attr = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
	        	if (attr.Length > 0) {
	        		return attr[0].Description;
	        	} else {
		        	return value.ToString();
	        	}
	        }
	        return base.ConvertTo(context, culture, value, destinationType);
        }
    }
