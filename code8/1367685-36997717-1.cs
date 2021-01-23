    public class Masque
    {
        public bool MasquerAdresse { get; set; }
        public bool MasquerCpVille { get; set; }
        public bool MasquerTelephone { get; set; }
        public bool MasquerFax { get; set; }
        public bool MasquerEmail { get; set; }
        public bool MasquerNom { get; set; }
        public static Masque FromBits(int bits)
        {
            return new Masque
            {
                MasquerAdresse = bits & 1,
                MasquerCpVille = bits & 2,
                ...
            };
        }
    }
