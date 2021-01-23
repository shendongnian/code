    public class DateTimeModelBinder : DefaultModelBinder
	{
		public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
		{
			var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
			if (value != null)
			{
				DateTime time;
                // here you can add your own logic to parse input value to DateTime
                //if (DateTime.TryParseExact(value.AttemptedValue, "d.m.Y H:i", CultureInfo.InvariantCulture, DateTimeStyles.None, out time))
				if (DateTime.TryParse(value.AttemptedValue, Culture.Ru, DateTimeStyles.None, out time))
				{
					return time;
				}
				else
				{
					bindingContext.ModelState.AddModelError(bindingContext.ModelName,
						string.Format("Date {0} is not in the correct format", value.AttemptedValue));
				}
			}
			return base.BindModel(controllerContext, bindingContext);
		}
	}
