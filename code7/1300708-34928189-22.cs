        public static IList<SelectListItem> ToSelectList<T>(this IEnumerable<T> list) {
            return ToSelectList<T>(list, list.FirstOrDefault());
        }
        public static IList<SelectListItem> ToSelectList<T>(this IEnumerable<T> list, T selectedItem) {
            var items = new List<SelectListItem>();
            var displayAttributeType = typeof(DisplayAttribute);
    
            foreach (var item in list) {
                string displayName;
    
                // multi-language: 
                // assume item is a enum value
                var field = item.GetType().GetField(item.ToString());
                try {
                    // read [Display(Name = @"someKey")] attribute
                    var attrs = (DisplayAttribute)field.GetCustomAttributes(displayAttributeType, false).First();
                    // lookup translation in the Resource file
                    displayName =  Resources.ResourceManager.GetString(attrs.Name);
                } catch {
                    // no attribute -> use enum value name
                    displayName = item.ToString();
                }
    
                // after postback, selectedItem is the Model passed from MVC
                var isSelected = false;
                if (selectedItem != null) {
                    isSelected = (selectedItem.ToString() == item.ToString());
                }
    
                items.Add(new SelectListItem {
                    Selected = isSelected,
                    Text = displayName,
                    Value = item.ToString()
                });
            }
    
            return items;
        }     
