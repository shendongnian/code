        public static IList<SelectListItem> ToSelectList<T>(this IEnumerable<T> list) {
            return ToSelectList<T>(list, list.FirstOrDefault());
        }
        public static IList<SelectListItem> ToSelectList<T>(this IEnumerable<T> list, T selectedItem) {
            var items = new List<SelectListItem>();
            var displayAttributeType = typeof(DisplayAttribute);
    
            foreach (var item in list) {
                string displayName;
    
                //For list of enums
                var field = item.GetType().GetField(item.ToString());
                try {
                    // Attribute your enum values with [Display(Name = @"someKey")]
                    // Translation happens here using the Resource file
                    var attrs = (DisplayAttribute)field.GetCustomAttributes(displayAttributeType, false).First();
                    displayName =  Resources.ResourceManager.GetString(attrs.Name);
                } catch {
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
