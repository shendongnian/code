            var fileName = "reiksmes.json";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
            var path = Path.Combine(documentsPath, fileName);
           
            Console.WriteLine(path);
            if (!File.Exists(path))
            {                
                var s = AssetManager.Open(fileName);
                // create a write stream
                FileStream writeStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                // write to the stream
                ReadWriteStream(s, writeStream);
            }
