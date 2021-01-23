    private RootObject Parse(string jsonString)
    {
       dynamic json = JsonConvert.DeserializeObject(jsonString);
       RootObject result = new RootObject()
       {
            response = new Response()
            {
                  success = json.response.success,
                  current_time = json.response.current_time,
                  message = json.response.message,
                  items = ParseItems(json.response.items)
            }  
       };
       return result;
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
