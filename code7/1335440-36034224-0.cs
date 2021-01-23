    public ApartmentModel(IDictionary<string, object> item)
    {
        Id = (int)item[nameof(Id)];
        Title = item[nameof(Title)].ToString();           
    }
    public override IDictionary<string, object> FieldsValues()
    {
        var item = new Dictionary<string, object>
        {
            [nameof(Id)] = Id,
            [nameof(Title)] = Title                
        };
        return item;
    }
