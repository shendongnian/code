    public class PhoneModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            // If not the type that this binder wants, return null.
            if (!typeof(List<PhoneTable>).IsAssignableFrom(bindingContext.ModelType))
            {
                return null;
            }
            var phoneTable = new List<PhoneTable>();
            int i = 1;
            while (true)
            {
                var phoneField = bindingContext.ValueProvider.GetValue("Phone" + i.ToString());
                if (phoneField != null)
                {
                    phoneTable.Add(new PhoneTable() { Number = phoneField.AttemptedValue });
                    i++;
                    continue;
                }
                break;
            }
            return phoneTable;
        }
    }
