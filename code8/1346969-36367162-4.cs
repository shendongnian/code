    private void ReadWater()
    {
        string path = "Todayfile.txt";
        // if there is no file in this name ( Todayfile.txt )
        if(!System.IO.File.Exists(path)) {
            // Create a file to write to.
            using (StreamWriter sw = File.CreateText(path)) {
                sw.WriteLine("Hello");
                sw.WriteLine("And");
                sw.WriteLine("Welcome");
            }
        }
        //at this point file should exist.
        // Open the file to read from.
        using (StreamReader sr = File.OpenText(path)) {
            string s = "";
            while ((s = sr.ReadLine()) != null) {
                Console.WriteLine(s);
            }
        } 
    }
