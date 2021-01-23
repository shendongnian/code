    XmlSerializer deserializer = new XmlSerializer(typeof(XMLCD));
    XMLCD XmlData;
    using (var reader = new StreamReader(this.opnFileName))
    {
        XmlData = deserializer.Deserialize(reader) as XMLCD;
    }
    // loop over all Personnel to cleanse their AddressDirectoryList.AddressList
    foreach (Personnel p in XmlData.PersonnelList)
    {
        // RemoveAll predicate checks if ALL properties are null or empty
        p.AddressDirectoryList.AddressList.RemoveAll(a =>
            (string.IsNullOrEmpty(a.HouseNo) &&
             string.IsNullOrEmpty(a.StreetName) &&
             string.IsNullOrEmpty(a.City))
        );
    }
