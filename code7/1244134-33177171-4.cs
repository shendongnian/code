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
         List<Item> itemList = new List<Item>();
         foreach (var item in items)
         {
             itemList.Add(new Item()
             {
                  property1 = item.Value.property1,
                  property2 = item.Value.property2,
                  property3 = item.Value.property3
             });
         }
         return itemList;
    }
