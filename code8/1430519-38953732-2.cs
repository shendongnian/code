    public class CreateSomethingTypeConverter : TypeConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext context, 
           System.Globalization.CultureInfo culture, object value)
        {
			var model = value as IUserAware;
			if (model != null)
				model.UserId = context.HttpContext.User.Id;
       
            return base.ConvertFrom(context, culture, model);
        }
    }
