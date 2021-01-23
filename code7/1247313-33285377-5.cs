    public class Program
    {
       public static void Main(string[] args)
       {
    		string[] stringSeparators = new string[] { "CARD#" };
           var CardTrans = new List<Description>()
           {
               new Description(){Desc3="test test test CARD#1234"},
               new Description(){Desc3="dsd dsftest CARD#1234"},
               new Description(){Desc3="jjjjj iiiiii kkkk CARD#1234"},
               new Description(){Desc3="ujeuejduejtest test CARD#9999"},
               new Description(){Desc3="2323fseff dsftest CARD#9999"},
               new Description(){Desc3="sdfsd fsdsdf kkkk CARD#9999"}
           };
           
    		var cardsList=CardTrans
    			.Where(ct=>ct.Desc3.Contains("CARD#"))
    			.GroupBy(key=>key.Desc3.Split(stringSeparators,StringSplitOptions.None)[1])
    			.Select(x=>Tuple.Create<string,IEnumerable<Description>>(x.Key,x));
    		cardsList.Dump();
       }
    }
    
    public class Description
    {
       public Description(){}
    
       public string Desc1 { get; set; }
       public string Desc2 { get; set; }
       public string Desc3 { get; set; }
       public DayMonthYear OriginalDate { get; set; }
       public DayMonthYear PostedDate { get; set; }
    }
    
    public class DayMonthYear{}
