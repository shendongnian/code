    public class Data
    {
         public static char Separator = '-'; //here is your separator
         public int id { get; set; }
         public string BBBBegin { get; set; }
         public string BBBEnd { get; set; }
         public string BBBCode { get { return BBBBegin + Separator + BBBEnd; } }
    }
