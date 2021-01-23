    [WebMethod]
    public void saveDayEntries(List<DayEntry> listofEntries, string language){}
    [XmlInclude(typeof(DataEntry))]
    [XmlInclude(typeof(DataEntryLD))]
    class DayEntry{}
