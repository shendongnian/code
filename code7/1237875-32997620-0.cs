        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (value == null || string.IsNullOrEmpty(value.AttemptedValue))
            {
                return null;
            }
            else
            {
                int n;
                string s = (string)value.ConvertTo(typeof(string));
                if (s.StartsWith("{") || s.StartsWith("["))
                {
                    var js = new JavaScriptSerializer();
                    var result = js.Deserialize<object>(s);
                    return result;
                }
                else if (int.TryParse(s, out n))
                {
                    return n;
                }
                return s;
            }
        }
