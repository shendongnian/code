    // Declare the hashtable reference.
    Hashtable responseFromWebService  = null;
    // Open the file containing the data that you want to deserialize.
    FileStream fs = new FileStream("DataFile.dat", FileMode.Open);
    try 
    {
        BinaryFormatter formatter = new BinaryFormatter();
        // Deserialize the hashtable from the file and 
        // assign the reference to the local variable.
        responseFromWebService = (Hashtable) formatter.Deserialize(fs);
    }
    catch (SerializationException e) 
    {
        Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
        throw;
    }
    finally 
    {
        fs.Close();
    }
