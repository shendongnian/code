    public class DateTimeBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            DateTime date;
            var displayFormat = SmartSession.DateTimeFormat;
            if (DateTime.TryParseExact(value.AttemptedValue, displayFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                return date;
            }
            else
            {
                bindingContext.ModelState.AddModelError(bindingContext.ModelName,"Invalid Format");
            }
            return base.BindModel(controllerContext, bindingContext);
        }
    }
