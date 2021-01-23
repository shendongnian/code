    private RootObject Parse(string jsonString)
    {
       dynamic jsonObject = JsonConvert.DeserializeObject(jsonString);
       RootObject parsed = new RootObject()
       {
            response = new Response()
            {
                  success = jsonObject.response.success,
                  current_time = jsonObject.response.current_time,
                  message = jsonObject.response.message,
                  items = ParseItems(jsonObject.response.items)
            }  
       };
       return parsed;
    }
    private List<Item> ParseItems(dynamic items)
    {
         int counter = 1;
         string name = String.Format("item#{0}", counter);
         List<Item> itemList = new List<Item>();
         while(items[name] != null)
         {
             itemList.Add(new Item()
             {
                  property1 = items[name].property1,
                  property2 = items[name].property2,
                  property3 = items[name].property3
             });
             name = String.Format("item#{0}", ++counter);
         }
         return itemList;
    }
