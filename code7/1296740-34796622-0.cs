    public class DeserializedGame
    {
        public string Atcommon { get; set; }
        public string Canationalbroadcasts { get; set; }
        public string Ata { get; set; }
        public bool Rl { get; set; }
        public int Atsog { get; set; }
        public string Bs { get; set; }
        public string Htcommon { get; set; }
        public int Id { get; set; }
        public string Atn { get; set; }
        public int Hts { get; set; }
        public string Atc { get; set; }
        public string Htn { get; set; }
        public string Usnationalbroadcasts { get; set; }
        public bool Gcl { get; set; }
        public string Hta { get; set; }
        public int? Ats { get; set; }
        public string Htc { get; set; }
        public int Htsog { get; set; }
        public string Bsc { get; set; }
        public int Gs { get; set; }
        public bool Gcll { get; set; }
        public static implicit operator DeserializedGameBLL(DeserializedGame game)
       {
           return new DeserializedGameBLL()
           {
               pubAtcommon = pubAtcommon,
               Canationalbroadcasts= Canationalbroadcasts,
               Ata = Ata ,
               Rl = Rl ,
               Atsog = Atsog ,
               Bs = Bs ,
               Htcommon = Htcommon ,
               Id = Id ,
               Atn =Atn ,
               Hts =Hts ,
               Atc =Atc ,
               Htn =Htn,
               Usnationalbroadcasts =Usnationalbroadcasts,
               Gcl =Gcl,
               Hta =Hta,
               Ats =Ats,
               Htc =Htc,
               Htsog = Htsog,
               Bsc = Bsc,
               Gs = Gs,
               Gcll = Gcll 
            };
        }
    }
