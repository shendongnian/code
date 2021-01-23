    public class Entry
    {
        public DateTime DateTime { get; set; } //Combine the Date and the Time 
        public string AppointmentType { get; set; }
        public string Name { get; set;  }
        public override string ToString()
        {
            return Name + " " + AppointmentType + " " + DateTime.ToString("dd.MM.yyyy HH:mm:ss");
        }
    }
