     // classes used
     public class ExtrapolatedItem
     {
         public int Hour{get;set;}
         public int Minute{get;set;}
     }
    
    public class Item{
        public DateTime Date{get;set;}
        public DateTime EndDate{get;set;}
    }
    // method 
    private static IEnumerable<ExtrapolatedItem> Extrapolate(Item item)
    {
        for(var d = item.Date;d<=item.EndDate; d = d.AddMinutes(1))
        {
            yield return new ExtrapolatedItem{ Hour = d.Hour, Minute = d.Minute};
        }
    }
