         private static void Serialize(Type serializableType, 
                               Object objectToSerialize, FileStream fs)
         {
            MemoryStream stream1 = new MemoryStream();
            try
            {
                DataContractSerializer serializer = 
                       new DataContractSerializer(typeof(serializableType));
                serializer.WriteObject(stream1, objectToSerialze);
                Console.WriteLine("Successfully Serialized");
            }
            catch (Exception ex)
            {
               Console.WriteLine("Unable to Serialize");
               Console.WriteLine(ex.Message);
            }
          }
    
          private static Object Deserialize(FileStream fs)
          {                        
             try
             {
                  stream1.Position = 0;
                  return serializer.ReadObject(stream1);
        
                  Console.WriteLine("Deserialized record: {0}", record2.ToString());
                  Console.WriteLine("Successfully Deserialized");
              }
              catch (Exception ex)
              {
                  Console.WriteLine("Unable to Deserialize");
                  Console.WriteLine(ex.Message);
              }
             return objectsToDeserialze;
            }
                
