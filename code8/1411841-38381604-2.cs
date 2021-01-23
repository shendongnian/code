            private static void Serialize(List<object> objectsToSerialze, FileStream fs)
            {
                BinaryFormatter BF = new BinaryFormatter();
                try
                {
                    BF.Serialize(fs, objectsToSerialze);
                    Console.WriteLine("Successfully Serialized");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unable to Serialize from binary format");
                    Console.WriteLine(ex.Message);
                }
            }
            private static List<object> Deserialize(FileStream fs)
            {
                BinaryFormatter BF = new BinaryFormatter();
                List<string> objectsToDeserialze = null;
                try
                {
                    objectsToDeserialze = (List<string>)BF.Deserialize(fs);
                    Console.WriteLine("Successfully Deserialized");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unable to Deserialize from binary format");
                    Console.WriteLine(ex.Message);
                }
                return objectsToDeserialze;
            }
        }
