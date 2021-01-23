    public class SmsReceiptModelBinder : IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType != typeof(SmsReceiptModel))
            {
                return false;
            }
            Type t = typeof(SmsReceiptModel);
            var smsDetails = new SmsReceiptModel();
            foreach (var prop in t.GetProperties())
            {
                string propName = prop.Name.Replace('_', '-');
                var currVal = bindingContext.ValueProvider.GetValue(
                         propName);
                if (currVal != null)
                    prop.SetValue(smsDetails, Convert.ChangeType(currVal.RawValue, prop.PropertyType), null);
            }
            bindingContext.Model = smsDetails;
            return true;
        }
    }
