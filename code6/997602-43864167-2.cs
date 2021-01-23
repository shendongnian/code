    public class UserConverter: TypeConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public override StandardValuesCollection GetStandardValues(
            ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(_senderIds);
        }
    }
