    class Test
    {
        List<Item> Items = new List<Item>();
        List<Item> GetList()
        {
            return getList_Rec(this.Items);
        }
    
        private List<Item> getList_Rec(List<Item> items)
        {
            var result = new List<Item>();
            result.AddRange(items);
            items.ForEach(x => result.AddRange(x.Children));
            return result;
        }
    }
