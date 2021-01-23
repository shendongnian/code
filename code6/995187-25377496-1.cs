    public class DeserializeFeatureLayerExtension
    {
    
        public void desiralizeXML()
        {
            XmlSerializer fledeserializer = new XmlSerializer(typeof(FeatureLayerExtension));
            TextReader reader = new StreamReader(file path);
            FeatureLayerExtension fleData = (FeatureLayerExtension)deserializer.Deserialize(reader);
            reader.Close();
        //Fetch the list of SimpleFillSymbol objects
        List<SimpleFillSymbol> listSimpleFillSymbol = (from e in fleData
                                                         select e.SimpleFillSymbolList);
    
        }
    
    }
