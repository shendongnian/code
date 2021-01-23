    public class Pref{
        public Dictionary<string, string> PreferredPartners =  new Dictionary<string,string>();
    
        public Pref(){
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
              var p = new Pref();  //Instantiate your pref class.
              .
              if(p.PreferedPartners.ContainsKey("someIDpart1"))
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
