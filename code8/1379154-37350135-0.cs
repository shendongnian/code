    if (prop.Name == "CurrentSample")
    {
        object currentSample = prop.GetValue(dataItem.Value, null);
        var internProperties = prop.GetType().GetProperties();
        foreach (var internProperty in internProperties)
        {
            System.Diagnostics.Debug.WriteLine("internProperty.Name + " : " + internProperty.GetValue(currentSample , null));
        }
    }
