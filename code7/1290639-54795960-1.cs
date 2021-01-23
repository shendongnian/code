    AbstractModel instance = new RealModel()
                                 {
                                     PropertyA = "foo",
                                     PropertyA = "bar"
                                 };
    
    using (TextWriter file = new StreamWriter("path"))
    using (var csv = new CsvWriter(file))
    {
        csv.WriteRecord((object)instance);
    }
