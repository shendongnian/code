    public class Partner : EntityBase
    {   //Name
        public string Name { get; set; }
        //Address
        public string Street { get; set; }
        ...
        //It is important to return the formated string
        public string DisplayName { get { return string.Format("{0}", Name); } }
    }
