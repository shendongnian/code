    internal IEnumerable<Good> Select()
    {
        using (GoodsContext context = new GoodsContext())
        {
            var items = (from Items in context.Goods
                         select Items).ToList();
            return items;
        }
    }
