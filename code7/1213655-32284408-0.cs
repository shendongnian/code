    Hashtable DTVector = new Hashtable();
    
    DTVector.Add("key",12);
    DTVector.Add("foo",42.42);
    DTVector.Add("bar",42*42);
    
    // write the data to a file
    var binformatter = new  System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
    using(var fs = File.Create("c:\\temp\\vector.bin"))
    {
        binformatter.Serialize(fs, DTVector);
    }
    
    // read the data from the file
    Hashtable vectorDeserialized = null;
    using(var fs = File.Open("c:\\temp\\vector.bin", FileMode.Open))
    {
         vectorDeserialized = (Hashtable) binformatter.Deserialize(fs);
    }
    
    // show the result
    foreach(DictionaryEntry entry in vectorDeserialized)
    {
        Console.WriteLine("{0}={1}", entry.Key,entry.Value);
    }
