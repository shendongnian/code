        public static void Sort(this ListItemCollection items)
        {
            var itemsArray = new ListItem[items.Count];
            items.CopyTo(itemsArray,0);
 
            Array.Sort(itemsArray, (x, y) => (string.Compare(x.Value, y.Value, StringComparison.Ordinal)));
            items.Clear();
            items.AddRange(itemsArray);
        }
