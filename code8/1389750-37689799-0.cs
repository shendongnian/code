    List<MyObject> list = new List<MyObject>(); // Simulate already deserialzied list
    myAutoSuggestBox.ItemsSource = list;
    myAutoSuggestBox.DisplayValue = "Combined";
 
    public class MyObject
    {
         public string City { get;set; }
         public string Country { get;set; }
         public string Combined 
         {
              get
              {
                  return $"{City}, {Country}";
              }
         }
    }
