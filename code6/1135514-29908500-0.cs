    public ItemProperties[] MyItems { get; set; }
    
    public int GrandTotal 
    {
        get 
        {
            var total = 0;
            foreach (var item in MyItems)
                total += item.Total;
    
            return total;
        }
    }
