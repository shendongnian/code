    public class items
    {
        public string infoOne { get; set;}
        public string infoTwo { get; set;}
        public string infoFull
        {
            get { return $"{infoOne} {infoTwo}"; }
        }
    }
