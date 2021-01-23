    public class DkDateTime
    {
        public DateTime dkDateTime;
        public static bool TryParse(string s, out DkDateTime result) {
            result = null;
            var dateTime = default(DateTime);
            if (DateTime.TryParseExact(s, "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out dateTime)) {
                result = new DkDateTime { dkDateTime = dateTime };
                return true;
            }
            return false;
        }
    }
     public class DkDateTimeModelBinder : IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext) {
            if (bindingContext.ModelType != typeof(DkDateTime)) {
                return false;
            }
            ValueProviderResult val = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (val == null) {
                return false;
            }
            string key = val.RawValue as string;
            if (key == null) {
                bindingContext.ModelState.AddModelError(
                    bindingContext.ModelName, "Wrong value type");
                return false;
            }
            DkDateTime result;
            if (DkDateTime.TryParse(key, out result)) {
                bindingContext.Model = result;
                return true;
            }
            bindingContext.ModelState.AddModelError(
                bindingContext.ModelName, "Cannot convert value to DkDateTime");
            return false;
        }
    }
