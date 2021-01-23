    public class Ausgabe
    {
        public int Id { get; set; }
        public Mitarbeiter Mitarbeiter { get; set; }
        public Ausgabestatus Status { get; set; }
        public Bestellung Bestellung { get; set; }
        public String FullName
        {
            get { return Mitarbeiter.Nachname + " " + Mitarbeiter.Vorname; }
        }
    }
