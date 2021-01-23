    public IEnumerable<DataObject> ReadCSVFile(Stream input)
    {
      StreamReader reader = new StreamReader(input);
      string line;
      while ((line = reader.ReadLine()) != null) // this sets and checks line at the same time
      {
        DataObject data = new DataObject();
        
        // ... fill in the parameters of your data object here ...
        
        // this will return the single data object,
        // let your LINQ query process it, and then continue the loop
        yield return data;
      }
      reader.Close();
    }
