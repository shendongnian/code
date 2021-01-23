    public class VoetbalPloeg
    {
        public int Id { get; set; }
        public string PloegNaam { get; set; }
        public int StamNummer { get; set; }
        public virtual ICollection<Speler> Spelers { get; set; }
    }
   
