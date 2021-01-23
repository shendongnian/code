    public class SWTTFields
    {
        public static readonly SWTTFields ISO;
        public static readonly SWTTFields EPC;
    
        static SWTTFields()
        {
            ISO = new SWTTFields("ISO", 1, 2);
            EPC = new SWTTFields("EPC", 3, 4);
        }
    }
