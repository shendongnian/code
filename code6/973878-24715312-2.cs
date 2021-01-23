    // Open the file.
    using (FileStream fs = new FileStream(fontFileNames, FileMode.Truncate, FileAccess.ReadWrite))
    using (StreamWriter sw = new StreamWriter(fs))
    { 
        //Add string to the file        
        sw.WriteLine("Test");
        sw.Flush();
        fs.Position = 0;
        // Create a BinaryReader on the file.
        using (BinaryReader br = new BinaryReader(fs))
        {
            /* rest of your code here */
        }
    }
