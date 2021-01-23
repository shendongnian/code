    public static class helper {
        public static IEnumerable<System.Web.Mvc.SelectListItem> getIntoDropDownState<T>(this List<T> data, string textField, string valueField) where T : class {
            
            return new System.Web.Mvc.SelectList(data, valueField, textField);
        }
    }
