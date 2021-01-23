            ClientContext ctx = new ClientContext("https://...");
            List list = ctx.Web.Lists.GetByTitle("Idea");
            ListItemCollection items = list.GetItems(CamlQuery.CreateAllItemsQuery());
            ctx.Load(items); // loading all the fields
            ctx.ExecuteQuery();
            foreach (var item in items)
            {
                ctx.Load(item);
                ctx.ExecuteQuery();
                // important thing is, that here you must have the right type
                // i.e. item["Modified"] is DateTime
                FieldUserValue val = item["Old_Created_By_Person"] as FieldUserValue;
                if (val != null)
                {
                    item["Author"] = val;
                    // do whatever changes you want
                    item.Update(); // important, rembeber changes
                    ctx.ExecuteQuery();
                    Console.WriteLine("Updating " + item.Id);
                }
            }
