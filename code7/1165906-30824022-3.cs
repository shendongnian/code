               var serializedArray = new JavaScriptSerializer().Deserialize<object[]>(filter);
                foreach (var item in serializedArray)
                {
                   foreach (var innerItem in (object[])item)
                   {
                       var element = innerItem;
                   }
                }
                
