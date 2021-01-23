    public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var testFormat = bindingContext.ModelMetadata.DisplayFormatString;
            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (!string.IsNullOrEmpty(testFormat) && value != null)
            {
                DateTime testDate;
                testFormat = testFormat.Replace("{0:", string.Empty).Replace("}", string.Empty);
                // use the format specified in the testFormat attribute to parse the date
                if(DateTime.TryParseExact(value.AttemptedValue, testFormat, new System.Globalization.CultureInfo("es-ES"), DateTimeStyles.None, out testDate);)
                {
                    return testDate;
                }
                else
                {
                    //if you want allow nulls
                    //date = DateTime.Now.Date;
                    //return date;
                    bindingContext.ModelState.AddModelError(
                        bindingContext.ModelName,
                        string.Format("{0} is an invalid date format", value.AttemptedValue)
                    );
                }
            }
            return base.BindModel(controllerContext, bindingContext);
        }
