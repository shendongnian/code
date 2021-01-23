    // Then we save the byte array to a file when needed
    string filename;
    using (System.IO.FileStream fs = new System.IO.FileStream(filename, System.IO.FileMode.Create))
    {
        fs.Write(documentBytes, 0, documentBytes.Length);
    }
