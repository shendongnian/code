    var propName = "CSName";
    var keyValues = Management
        .GetInstances()
        .Cast<ManagementObject>()
        .Select(obj =>
        new
        {
            name = propName,
            value = obj[propName]
        })
        .Where(obj => 
             obj.value != null);
    var result =
        String.Join(
            "",
            keyValues
                .Select(kv =>
                    String.Format("<br><font color = red>{0} : {1} </font>", kv.name, kv.value)));
    TxtBox.Text += result;
