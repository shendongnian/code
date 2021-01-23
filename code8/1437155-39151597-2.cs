    public static class helper {
        public static IEnumerable<SelectListItem> getIntoDropDownState<T>(this List<T> data, string textField, string valueField) where T : class {
            var type = typeof(T);
            var textPropertyInfo = type.GetProperty(textField);
            var valuePropertyInfo = type.GetProperty(valueField);
            return data.Select(x => new SelectListItem {
                Text = (string)textPropertyInfo.GetValue(x),
                Value = (string)valuePropertyInfo.GetValue(x)
            });
        }
    }
