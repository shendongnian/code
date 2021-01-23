    public class Klient_has_SklepIndexData
    {
        public IList<Klient> Klients { get; set; }
        public IList<Klient_has_Sklep> Klient_has_Skleps { get; set; }
        public Klient_has_SklepIndexData()
        {
            Klients = new List<Klient>();
            Klient_has_Skleps = new List<Klient_has_Sklep>();
        }
    }
