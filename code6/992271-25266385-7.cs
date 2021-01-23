    public class Pref
    {
        public static Dictionary<string, string> PreferredPartners =  new Dictionary<string,string>()
        {
            {"ID1part1" , "ID1part2"},
            {"ID2part1" , "ID2part2"}
        };
    }
    void Main()
    {
        if(Pref.PreferedPartners.ContainsKey("someIDpart1"))
        {
           Console.WriteLine(Pref.PreferredPartners["ID1part1"]);
           ....
        }
        else
        {
           ....;
        }
    }
