        public class DecimalModelBinder : IModelBinder
        {
            public object BindModel(ControllerContext controllerContext,
                ModelBindingContext bindingContext)
            {
                var valueResult = bindingContext.ValueProvider
                    .GetValue(bindingContext.ModelName);
                var modelState = new ModelState {Value = valueResult};
                object actualValue = null;
                try
                {
                    //Check if this is a nullable decimal and a null or empty string has been passed
                    var isNullableAndNull = (bindingContext.ModelMetadata.IsNullableValueType &&
                                              string.IsNullOrEmpty(valueResult.AttemptedValue));
    
                    //If not nullable and null then we should try and parse the decimal
                    if (!isNullableAndNull)
                    {
                        actualValue = decimal.Parse(valueResult.AttemptedValue, NumberStyles.Any, CultureInfo.CurrentCulture);
                    }
                }
                catch (FormatException e)
                {
                    modelState.Errors.Add(e);
                }
    
                bindingContext.ModelState.Add(bindingContext.ModelName, modelState);
                return actualValue;
            }
        }
    }
