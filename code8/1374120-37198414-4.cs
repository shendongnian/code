     public class Speler
    {
        public int Id { get; set; }
        public string VoorNaam { get; set; }
        public string AchterNaam { get; set; }
        public int Rugnummer { get; set; }
        public string Positie { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }
        public DateTime GeboorteDatum { get; set; }
        // Forgein Key
        public int VoetbalPloegId { get; set; }
    }
