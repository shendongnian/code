    class Measurement 
    {
        public Volume Volume {get; set;}
        public Weight Weight {get; set;}
       public Measurement (Volume v) { Volumme = v; Weight = null;}
       public Measurement (Weight w) { Volumme = null; Weight = w;}
    }
