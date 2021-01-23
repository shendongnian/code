    public class Test
        {
            [Display(Name = "Hardware purchasing")]
            [DataType(DataType.Currency)]
            public decimal Hardware { get; set; }
        }
    
    
        public class TestModelBinder : DefaultModelBinder
        {
            public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
            {
                var result = bindingContext.ValueProvider.GetValue("Hardware");
    
                if (result != null)
                {
                    decimal hardware;
                    if (Decimal.TryParse(result.AttemptedValue, NumberStyles.Currency, null, out hardware))
                        return new Test { Hardware = hardware };
    
                    bindingContext.ModelState.AddModelError("Hardware", "Wrong amount format");
                }
    
                return base.BindModel(controllerContext, bindingContext);
            }
        }
