    var RegisteryEntryList = new List<RegistryEntry>();
    foreach (var register in registers)
    {
        //create a new RegistryEntry
        var obj = new RegistryEntry();
        //convert your string to an int value and save it
        obj.index = Convert.ToInt32(register.Attributes["Index"].Value.Split('x')[1], 8);
        obj.datatype = Convert.ToInt32(register.Attributes["DataType"].Value.Split('x')[1], 8);
          
        //... your remaining properties
        RegisteryEntryList.Add(obj);
    }
