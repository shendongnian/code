         using (var dtCntx = new MyDbContext())
         {
                var folder = dtCntx.Folders.Include(f => f.Letters).FirstOrDefault();
                var folder2 = dtCntx.Folders.FirstOrDefault(f => f.Id == folder.Id);
                if (folder == folder2) Console.WriteLine("Equals"); // Call Folder.Equals
                dtCntx.Folders.Remove(folder);
                dtCntx.SaveChanges();
            }
