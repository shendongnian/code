    abstract class Weather
    {
     public string ImageUrl{get;set;};
    }
    
    class MildWeather : Weather
    {
       public MildWeather()
      {
          ImageUrl = "your specific image for MildWeather";
      } 
    }
