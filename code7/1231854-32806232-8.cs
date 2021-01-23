    // Send string
    string ext = ".txt";
    byte [] textBytes = Encoding.ASCII.GetBytes(ext);
    ns.Write(textBytes, 0, textBytes.Length); 
    
    // Now, send integer - the file length limit parameter
    int limit = 333;
    byte[] intBytes = BitConverter.GetBytes(limit);
    ns.Write(intBytes, 0, intBytes.Length); // send integer - mind the endianness
