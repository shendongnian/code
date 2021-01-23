        public FilesCollection loadCollectionFromDirectory(string directory) 
        {
            string errorMessage;
            FilesCollection collection = new FilesCollection(_collectionType);
            string[] files = Directory.GetFiles(directory,"*.dll");
            foreach (string file in files)
            {
               collection.AddNewFileToCollection(file, out errorMessage);
            }
           // files = null;
            return collection;
        }
