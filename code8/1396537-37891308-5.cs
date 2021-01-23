    List<object> sizeDS = new List<object>();
    foreach (SampleSize value in Enum.GetValues(typeof(SampleSize)))
    {
        sizeDS.Add(new
        {
            Name = value.ToString(),
            Value = (int)value
        });
    }
    cbo.DataSource = sizeDS;
