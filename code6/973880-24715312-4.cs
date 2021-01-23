    // Open the file.
    using (FileStream fs = new FileStream(fontFileNames, FileMode.Append, FileAccess.Write))
    using (StreamWriter sw = new StreamWriter(fs))
    { 
        //Add string to the file        
        sw.WriteLine("Test");
    }
    // Create a BinaryReader on the file.
    using (FileStream fs = new FileStream(fontFileNames, FileMode.Open, FileAccess.Read))
    using (BinaryReader br = new BinaryReader(fs))
    {
        byte[] bytes = br.ReadBytes((int)fs.Length);
        /* rest of your code here */
    }
