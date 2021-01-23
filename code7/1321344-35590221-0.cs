    public string GUID { get; set; }
    public myObject()
    {
        GUID = Guid.NewGuid().ToString();
    }
    <RadioButton GroupName="{Binding GUID}" />
