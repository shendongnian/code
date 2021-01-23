    public class CreateSomethingTypeConverter : TypeConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext context, 
           System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
			var model = base.ConvertFrom(context, culture, value, destinationType);
             if(model != null && destinationType.GetInterfaces().Contains(typeof(IUserAware)))
             {
                //set user value
                model.UserId = ...
				
             }
       
            return model;
        }
    }
