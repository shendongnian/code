    using System;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    
    namespace Helpr
    {
        class Program
        {
            static void Main(string[] args)
            {
                int[] Chunks = new int[10 * 10]; //Created this dummy chunk array to show that it works
                for(int x = 0; x < 10; ++x)     
                {
                    for(int y = 0; y < 10; ++y)
                    {
                        Chunks[x + (10 * y)] = x * y;       //Set the data
                    }
                }
    
                SaveChunks(Chunks, "Chunks.world"); //Save the chunks with a file name to refer too later
    
                for(int i = 0; i < 100; ++i)
                {
                    Console.WriteLine(Chunks[i] + " "); //Write the data to the console so we can compare
                }
    
                Console.WriteLine(" ");
    
                Chunks = (int[])LoadChunks("Chunks.world"); //Load the file back into the chunk
    
                for (int i = 0; i < 100; ++i)
                {
                    Console.WriteLine(Chunks[i] + " "); //Log to see if it has worked
                }
    
                Console.ReadKey();                      //Pause so you can even read it!
            }
    
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
        }
    }
