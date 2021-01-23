    SortedDictionary<Categorys, string> catergoryDictionary = new SortedDictionary<Categorys, string>
    {
        {Categorys.Acceleration, "Acceleration"},
        {Categorys.Area, "Area"},
        {Categorys.Velocity, "Speed"}
    };
    
    CbCategory.DataSource = new BindingSource(catergoryDictionary, null);
    CbCategory.ValueMember = "Key";
    CbCategory.DisplayMember = "Value";
