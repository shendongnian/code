    public enum SampleEnum
    {
        [Description("Some Value")]
        First = 1,
        [Description("Some Value")]      
        Second = 2,
        [Description("Some Value")]      
        Third = 3,
    }
    public static IList<ListItem> ToSelectList<T>(this Enum @enum, string firstOption = null)
    {
            var items = Enum.GetValues(typeof(T)).ToList<T>();
            var list = items.Select(x => new ListItem() { Text = Enum.Parse(typeof(T), x.ToString()).GetDescription(), Value = x.ToString() }).ToList();
            if (firstOption != null)
            {
                list.Insert(0, new ListItem() { Text = firstOption, Value = "" });
            }
            return list;
    }
