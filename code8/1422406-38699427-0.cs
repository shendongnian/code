    public Item 
    {
       public FieldType MyField { get; set; }
       public string MyFieldValue => MyField.Value;
       public string Description { get; set; }
       public int Capacity { get; set; }
    }
