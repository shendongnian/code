    public class Team 
    {
        public string Name {get; set;}  
        [XmlIgnoreAttribute]
        public Person[] Staff{ get; set; }
        public Person[] SerializationStaff
        {
            get
            { 
                  return Staff == null ? null : Staff.Where(s => s.NrOfHolidays > 10).ToArray(); 
            }
            set
            {
                 Staff = value;
            }
    }
    public class Person
    {
        public string Name {get; set;}
        public int NrOfHolidays {get; set;}
    }
