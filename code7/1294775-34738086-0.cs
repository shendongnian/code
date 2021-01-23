            var allPngFilesInGivenDirectory = Directory.EnumerateFiles("FilePath").Where(x => x.ToLower().EndsWith(".png"));
            var fileEnumerable = allPngFilesInGivenDirectory.GetEnumerator();
            string partialPath = checkBox.IsChecked ? "enabled" : "disabled";
            
            while (fileEnumerable.MoveNext())
            {
                string file = Path.GetFileName(fileEnumerable.Current);
                
                string disable_picture = "images/" + partialPath + "/" + file;
                string picture = "images\\" + partialPath + "\\" + file;
                Records[picture].ReplaceContents(imagesPath, disable_picture, content.FileRoot);
                UpdateImage();
            } 
