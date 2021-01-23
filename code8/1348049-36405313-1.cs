    public class MyCreateVM
    {
    
      public int ActivityID {get; set;}
      public int CityID {get; set;}
      public int RegID {get; set;}
    		
      public List<ActivityVM> Activities{ get; set; }
      public List<CityVM>  Cities{ get; set; }
      public List<RegVM> Registrations{ get; set; }
      ... etc
    }  
