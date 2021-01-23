        List<string> info = new List<string>();
        int counter = 0;
    // Open the file to read from.
        info = System.IO.File.ReadAllLines(path).ToList();
    // Find the lines up until (& including) the empty one
        foreach (string s in info)            
        {
            counter++;
            if(string.IsNullOrEmpty(s))
                break; //exit from the loop
        }
    // Remove the lines including the blank one.
        info.RemoveRange(0,counter);
