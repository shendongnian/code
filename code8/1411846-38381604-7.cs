                catch (Exception ex)
                {
                    Console.WriteLine("Unable to Deserialize from binary format");
                    Console.WriteLine(ex.Message);
                }
                return objectsToDeserialze;
            }
        }
