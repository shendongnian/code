    void Start()
    {
        BaseRestaurant restaurant = new BaseRestaurant();
        string test = "{  \r\n  \"Restaurants\":[  \r\n    {  \r\n        \"Name\":\"test\",\r\n        \"Id\":0,\r\n        \"PlateSet\":[  \r\n            {  \r\n                \"Title\":\"Plate1\",\r\n                \"Color\":{  \r\n                    \"r\":229,\r\n                    \"g\":0,\r\n                    \"b\":20,\r\n                    \"a\":255\r\n                },\r\n                \"Price\":12\r\n            }\r\n        ]\r\n    }\r\n  ]\r\n}";
    
    restaurant = JsonUtility.FromJson<BaseRestaurant>(test);
    if (restaurant == null)
    {
        Debug.Log("Null");
        return;
    }
    
    for (int i = 0; i < restaurant.Restaurants.Count; i++)
    {
        Debug.Log("Name: " + restaurant.Restaurants[i].Name);
        Debug.Log("ID: " + restaurant.Restaurants[i].Id);
        Debug.Log("PlateSet: " + restaurant.Restaurants[i].PlateSet);
    
        for (int j = 0; j < restaurant.Restaurants[i].PlateSet.Count; j++)
        {
            Debug.Log("Title: " + restaurant.Restaurants[i].PlateSet[j].Title);
    
            Debug.Log("Color r: " + restaurant.Restaurants[i].PlateSet[j].Color.r);
            Debug.Log("Color g: " + restaurant.Restaurants[i].PlateSet[j].Color.g);
            Debug.Log("Color b: " + restaurant.Restaurants[i].PlateSet[j].Color.b);
            Debug.Log("Color a: " + restaurant.Restaurants[i].PlateSet[j].Color.a);
    
            Debug.Log("Color r: " + restaurant.Restaurants[i].PlateSet[j].Price);
        }
      }
    }
