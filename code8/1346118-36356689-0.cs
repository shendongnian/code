        public ActionResult Account()
        {
            // Assign a value to class
            FileModel file = new FileModel();
            file.FileID = "1";
            file.UserID = "1";
            file.FileName = "Text.txt";
            file.AddedOn = "AddedOn";
            // Create instance for all file
            List<FileModel> allFiles = new List<FileModel>();
            
            // Add file model to list
            allFiles.Add(file);
            // Pass the file list to view
            return View(allFiles);
        }
