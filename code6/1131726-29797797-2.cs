    public class A
    {
        [IgnoreDataMember]  // not use in serializer process
        public DateTime Date { get; set; }
    }
    [XmlRoot(ElementName = "A")]
    public class B : A
    {
        [XmlAttribute("Date")]  // serializer the attribute called Date
        public string DateAsString
        {
            get { return _dateAsString; }
            set
            {
                Date = GetDateTime(value);
                _dateAsString = value;
            } 
        }
        private string _dateAsString;
        // Create the dateTime from the string here
        private static DateTime GetDateTime(string a)
        {
            // ...
            return new DateTime();
        }
    }
