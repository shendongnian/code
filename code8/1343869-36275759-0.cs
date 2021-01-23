    using (var ctx = new DatabaseEntities())
                {
                    var prop = from p in ctx.properties.Include("images")
                               select new
                               {
                                   id = p.pid,
                                   address = p.address,
                                   property = p.property1,
                                   images = (from img in p.images select new { images = img.images})
                               };
                    
                    var javaScriptSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                    string jsonString = javaScriptSerializer.Serialize(prop.ToList());
    
                    Console.WriteLine(jsonString);
                }
    
    Json returned from the above code is:
    
    [
       {
          "id": 1,
          "address": "Ashfield",
          "property": "property1",
          "images": [
             {
                "images": "img1"
             },
             {
                "images": "img2"
             }
          ]
       },
       {
          "id": 2,
          "address": "Burwood",
          "property": "property2",
          "images": [
             {
                "images": "img3"
             }
          ]
       }
    ]
