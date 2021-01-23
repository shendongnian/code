    var listTitle = "Documents";
    var folderUrl = "Archive/2013";
    using (var ctx = GetContext(url, userName, password))
    {
         //1. Get list items operation
         var list = ctx.Web.Lists.GetByTitle(listTitle);
         var items = list.GetListItems(folderUrl);
         ctx.Load(items);
         ctx.ExecuteQuery();
         //2. Update list items operation
         var watch = Stopwatch.StartNew();
         foreach (var item in items)
         {
               if(Convert.ToInt32(item["FSObjType"]) == 1) //skip folders
                   continue;
               item["LastReviewed"] = DateTime.Now;
               item.Update();
               //ctx.ExecuteQuery();
               Console.WriteLine("{0} has been updated", item["FileRef"]);
         }
         ctx.ExecuteQuery();  //execute batched request
         watch.Stop();
         Console.WriteLine("Update operation completed: {0}", watch.ElapsedMilliseconds); 
         Console.ReadLine();
    }
