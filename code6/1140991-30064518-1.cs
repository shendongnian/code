    public static class ListItemExtensions
    {
        public static void SetAsString(this SPListItem item, string colName, Action<string> destSetter)
        {
            if (item != null)
            {
                var colVal = item[colName].ToString();
                if (!string.IsNullOrEmpty(colVal))
                    destSetter(colVal);
            }
        }
    }
