    public class CategoryIdsModelBinder : IModelBinder
        {
            public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
            {
                if (bindingContext.ModelType != typeof(CategoryIds))
                {
                    return false;
                }
    
                var val = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
                if (val == null)
                {
                    return false;
                }
    
                var key = val.RawValue as string;
                if (key == null)
                {
                    bindingContext.ModelState.AddModelError(bindingContext.ModelName, "Wrong value type");
                    return false;
                }
    
                var values = val.AttemptedValue.Split(',');
                var ids = new List<int>();
                foreach (var value in values)
                {
                    int intValue;
                    int.TryParse(value.Trim(), out intValue);
                    if (intValue > 0)
                    {
                        ids.Add(intValue);
                    }
                }
    
                if (ids.Count > 0)
                {
                    var result = new CategoryIds
                    {
                        Ids= ids
                    };
    
                    bindingContext.Model = result;
                    return true;
                }
    
                bindingContext.ModelState.AddModelError(
                    bindingContext.ModelName, "Cannot convert value to Location");
                return false;
            }
