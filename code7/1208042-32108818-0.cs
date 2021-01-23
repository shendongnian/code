    DateTime dt = DateTime.Now;
    Console.WriteLine(dt);
    
    // Covert to OA Date
    double oadate = dt.ToOADate();
    Console.WriteLine(oadate);
    
    // Convert to byte array.
    byte[] datebytes = BitConverter.GetBytes(oadate);
