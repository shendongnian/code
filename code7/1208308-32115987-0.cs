    public class Restaurant 
    {
        public string Name {get; set;}
    }
    List<Restaurant> query = (from RESTAURANT in db.RESTAURANTs
                 where RESTAURANT.REST_ID == RestID
                 select new Restaurant() { Name = name }).ToList();
