    Task.Run(() =>
    {
        collectionOfFiles.AsParallel().ForAll(file => 
        {
            string newFile = string.Format(@"C:\{0}", file);
            System.IO.File.Copy(file, newFile);
            // Do more
         });
    });
