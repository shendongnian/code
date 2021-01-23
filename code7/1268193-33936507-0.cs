            var myimages = db.Images.ToList();    
            foreach (var img in myimages) 
            {
                var fileExist = files.FirstOrDefault(x => x.Name.ToString().Equals(img.name));
            
                if (fileExist == null)
                {
                   db.Images.Remove(img);
                   db.SaveChanges();
                }
            }
