    using (Stream stream = File.Open(serializationFile, FileMode.Open))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                deserializedObject = (MyClass)binaryFormatter.Deserialize(stream);
            }
