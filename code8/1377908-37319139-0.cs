    public static class CharSet
    {
        public static string Charset1 = "iso-8859-1";
        public static string Charset2 = "iso-8859-1";
    } 
    public static class Programm()
    {
       public static Main(){
           ParsePage1.Parse(CharSet.Charset1);
           ParsePage2.Parse(CharSet.Charset1);
           ParsePage3.Parse(CharSet.Charset2);
        }
    }
    
