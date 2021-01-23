        var jsonO = JArray.Parse(jsonOldFile);
        var jsonU = JArray.Parse(jsonUpdateFile);
        var item = jsonO.Children<JObject>();
        foreach(JObject innerData in jsonU)
        {
              if(innerData[Id] == item[Id])
               {
                  item[Name] = innerData[Name];
                  jsonO.Replace(item["Name"]);
                  //[or]
                  jsonO.Add(item["Name"});
               }
              else
               {
                  jsonO.Add(innerData);
               }
        }
