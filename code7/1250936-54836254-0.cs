               //prevent Owner to be saved (again)
                db.Entry(stockItem.Owner).State = EntityState.Unchanged;
              //prevent article to be saved (again)  
               db.Entry(stockItem.ArticleItem).State = EntityState.Unchanged;
                db.Stocks.Add(stockItem);
               
               //now just the properties (-> dbset of the stockItem get´s saved)
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
