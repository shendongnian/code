        using System.IO;
        [Serializable]    
        public class Components
        {
           ...
        }
    
        var components = new List<Components>();
        string pathToFile = @"c:\dev\components.bin";
    
        SerializeFile(pathToFile, components);
        var fetchComponents = DeserializeFile(pathToFile);
    
        private void SerializeFile(string file, IList<Components> data)
        {
            using (Stream stream = File.Open(file, FileMode.Create))
            {
               var formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
               formatter.Serialize(stream, data);
            }
        }
    
        private IList<Components> DeserializeFile(string file)
        {
            using (Stream stream = File.Open(file, FileMode.Create))
            {
                var formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                return (List<Components>)formatter.Deserialize(stream);
            }
        }
