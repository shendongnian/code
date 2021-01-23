               var serializedArray = new JavaScriptSerializer().Deserialize<object[]>(filter);
                foreach (var item in serializedArray)
                {
                   if (item is string)
                   {
                      var element = item;
                   }
                   else
                      foreach (var innerItem in (object[])item)
                      {
                         var element = innerItem;
                      }
                }
                
