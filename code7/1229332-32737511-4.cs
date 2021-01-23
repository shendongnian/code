    using (GagaShaggyContext db = new GagaShaggyContext())
        {
            ItemModel itemToChange = new ItemModel();
            itemToChange = (from i in db.Items
                            where i.ItemID == checkoutItem.Item.ItemID
                            select i).FirstOrDefault();
            if(itemToChange !=null)
            {
                itemToChange.FrontFeature = false;    
                objDBContext.Entry(itemToChange).State = EntityState.Modified;
                objDBContext.SaveChanges();
            }
        }
