    public static class EnumerableExtensions
    {
        public static IEnumerable<SelectListItem> AsSelectList<T>
        (
            this IEnumerable<T> dataList,
            string textField,
            string valueField,
            string defaultPrompt = "",
            object defaultValue = null)
        {
            IEnumerable<SelectListItem> returnList = new List<SelectListItem>();
            if (!string.IsNullOrEmpty(defaultPrompt))
            {
                returnList = Enumerable.Repeat(
                    new SelectListItem { Value = (string)defaultValue, Text = defaultPrompt },
                    count: 1);
            }
            var textProp = typeof(T).GetProperty(textField);
            var valueProp = typeof(T).GetProperty(valueField);
            returnList = returnList.Concat
                (dataList
                    .Select(x =>
                        new SelectListItem
                        {
                            Value = Convert.ToString(valueProp.GetValue(x)),//x["valueField"],
                            Text = Convert.ToString(textProp.GetValue(x)),//x.["textField"]
                        }).Distinct().ToList());
            return returnList;
        }
    }
