    const string fileName = "SimulatedTrain1.xml";
    XmlSerializer xml = new XmlSerializer(typeof(SimulatedTrain));
    public SimulatedTrain SimulatedTrain;
    public void LoadXML()
    {
        Contract.Assert(File.Exists(fileName));
 
        try
        {
            using (var fs = new FileStream(fileName, FileMode.Open))
            {
                SimulatedTrain = (SimulatedTrain)xml.Deserialize(fs);
            }                
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message, ex);
        }
    }
