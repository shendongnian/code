    public static class Pref{
        public static Dictionary<string, string> PreferredPartners =  new Dictionary<string,string>();
    
        static Pref(){
            PreferredPartners.Add("ID1part1" , "ID1part2");
            PreferredPartners.Add("ID2part1" , "ID2part2");
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
              .
              .
              .
              if(Pref.PreferedPartners.ContainsKey("someIDpart1"))
              {
                    do something;
              else
              {
                    do something else;
              }
              .
              .
              .
        }
    }
