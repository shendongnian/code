    private void ReadWater()
    {
        Stream fileStream;
        string path = "Todayfile.txt";
        // if there is no file in this name ( Todayfile.txt )
        if(!System.IO.File.Exists(path)) {
            // create a new file
            fileStream = System.IO.File.Create(path);
        } else {
            // if this file ( Todayfile.txt) is founded
            fileStream = System.IO.File.OpenRead(path);
        }
    
        // do whatever you intended to do with the file
        // ...
    }
