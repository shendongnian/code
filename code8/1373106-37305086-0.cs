    public class CityDataContext
    {
       DataDataContext dt = new DataDataContext();
       public IEnumerable<CityNameList> DisplayName
        {
           get
           {
               List<CityNameList> Details = new List<CityNameList>();
               var result = dt.AllCity().ToList();
               for (int j = 0; j < result.Count;j++ )
               {
                   CityNameList city = new CityNameList();
                   city .CityName= Convert.ToString(result[j].cityname);
                  
                   Details.Add(city);
               }
               return Details;
           }
       }
    }
