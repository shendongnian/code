    public List<ItemProperties> MyItems { get; set; }
    public int GrandTotal 
    {
        get {  return MyItems.Sum(item => item.Total); }
    }
