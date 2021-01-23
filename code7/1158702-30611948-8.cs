    public class PerfectDriver:IDriver
    {
       public PerfectDriver()
       {
         Name = "Vikram";
         Age = 30;
       }
       public int Age{get; set;}
       public string Name {get; set;}
       public string Drive()
       {
          return "Drive's perfectly";
       }
    }
