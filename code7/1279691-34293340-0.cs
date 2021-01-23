    public static class Helpers
    {
        public static string ToTotalCount(this DataGridView item)
        {
            return string.Format("Your search returned {0} results", item.Rows.Count);
        }
    }
    
