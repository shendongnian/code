    [Serializable]
    public class Color
    {
        public int r;
        public int g;
        public int b;
        public int a;
    }
    
    [Serializable]
    public class PlateSet
    {
        public string Title;
        public Color Color;
        public int Price;
    }
    
    [Serializable]
    public class Restaurant
    {
        public string Name;
        public int Id;
        public List<PlateSet> PlateSet;
    }
    
    [Serializable]
    public class BaseRestaurant
    {
        public List<Restaurant> Restaurants;
    }
