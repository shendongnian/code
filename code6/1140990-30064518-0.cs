    public static class ListItemExtensions
    {
        public static void SetAsString(this SPListItem item, string colName, ref string dest)
        {
            if (item != null)
            {
                var colVal = item[colName];
                if (!string.IsNullOrEmpty(colVal))
                    dest = colVal;
            }
        }
    }
