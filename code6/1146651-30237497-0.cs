    public static class EnumExtensions
    {
        public static List<SelectListItem> GetSelectListItems<T>(string defaultValue) where T : struct, IConvertible
        {
            if (!typeof (T).IsEnum)
                throw new ArgumentException("T must be an enumerated type");
            List<SelectListItem> items = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text = "Please select a lunch break...",
                    Value = string.Empty
                }
            };
            foreach (T item in Enum.GetValues(typeof(T)))
            {
                items.Add(new SelectListItem()
                {
                    Text = SiteUtilities.GetEnumDescription((Enum)(object)item),
                    Value = Convert.ToInt32(item).ToString()
                });
            }
            return items;
        }
    }
