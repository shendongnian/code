    using (Stream stream = File.Open(serializationPath, FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, objectToSerialize);
                stream.Close();
            }
