    public List<SomeObject> Data { get; set; }
    public int SelectedDataId { get; set; }
    public SomeObject SelectedData 
    {
        get { return Data.FirstOrDefault(p => p.Id == SelectedDataId); }
    }
