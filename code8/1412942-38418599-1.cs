    public static void SaveChunks(object Chunks, string filePath)
            {
                BinaryFormatter bf = new BinaryFormatter();                             //Create a BinaryFormatter to change the chunks into a binary string
                FileStream fs = new FileStream(filePath, FileMode.Create);              //Create a filestream to create a new file to store the string
    
                try
                {
                    bf.Serialize(fs, Chunks);                                           //Serialize the data into a file
                }
                catch (Exception e)                                                     //if an error occurs Post it!
                {
                    Console.WriteLine("Failed to create Chunk file! " + e);
                }
                finally
                {
                    fs.Close();                                                         //Then close the filestream to prevent memory leaks
                }
            }
    
            public static object LoadChunks(string filePath)
            {
                BinaryFormatter bf = new BinaryFormatter();                             //Create a BinaryFormatter to convert the binary string to an object
                FileStream fs = new FileStream(filePath, FileMode.Open);                //Create a filestream to create a new file to provide the string
    
                try
                {
                    return bf.Deserialize(fs);                                          //Deserialize the data into an object
                }
                catch (Exception e)                                                     //Catch any errors if they occur
                {
                    Console.WriteLine("Chunk load failed! " + e);
                    return null;
                }
                finally
                {
                    fs.Close();                                                         //Then close the filestream to prevent memory leaks
                }
            }
