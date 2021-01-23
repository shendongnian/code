    public class MyConverter : TypeConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            // you need to get the list of values from somewhere
            // in this sample, I get it from the MyClass itself
            var myClass = context.Instance as MyClass;
            if (myClass != null)
                return new StandardValuesCollection(myClass.Names);
            return base.GetStandardValues(context);
        }
    }
