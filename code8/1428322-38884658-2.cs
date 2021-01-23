    public class MyClassConverter : ExpandableObjectConverter
    {
        ...
        public override object ConvertFrom(ITypeDescriptorContext context,
                                           CultureInfo culture, object value)
        {
            GridItem gridItem = context as GridItem;
            object itemValue = gridItem == null ? null : gridItem.Value;
    
            if (value is string)
            {
                MethodInfo m = itemValue.GetType().GetMethod("ConvertFromString");
                return m.Invoke(null, new object[] { value, itemValue });
            }
    
            return base.ConvertFrom(context, culture, value);
        }
    }
