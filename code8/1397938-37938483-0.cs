    public class Wynik
    {
        public string Token { get; set; }
        public DateTime DataCzasWaznosci { get; set; }
    }
    /*Deserialization part */
    string backstr = sr.ReadToEnd();
    Wynikm = JsonConvert.DeserializeObject<Wynik>(backstr);
