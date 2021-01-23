     //in your action
     //add the images to the item
     item.Images.Add(new Image { ImageUrl = ... });
     //you should be able to just insert the whole entity graph here
     db.Items.Add(item);
     db.SaveChanges();
