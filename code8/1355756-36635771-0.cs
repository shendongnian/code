    public static class HelperMethod
    {
        public static List<QueryClassObj> Extend(this List<QueryClassObj> items)
        {
            while (items.Count < 10)
            {
                items.Add(new QueryClassObj());
            }
            return items;
        }
    }
