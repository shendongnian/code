    public class Restaurant
    {
        public string RestaurantName { get; set; }
        public string CategoryName { get; set; }
        public string FourSquareID { get; set; }
    }
    
    public class rest_collection
    {
        public List<Restaurant> restaurants { get; set; }
    }
---
    var result = new JavaScriptSerializer().Deserialize<rest_collection>(yourjson);
