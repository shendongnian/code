    var desiredProperties = new List<string>
    {
        "saon",
        "paon"
    };
    IEnumerable<PropertyInfo> pis = jsonAddressModel.GetType().GetProperties();
    var filteredPropertyInfos = pis.Where(pi => desiredProperties.Contains(pi.Name));
    foreach (PropertyInfo prop in filteredPropertyInfos)
    {
       // ...
    }
