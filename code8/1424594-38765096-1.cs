    namespace ConsoleApplication1
    {
        using Newtonsoft.Json;
        using System;
        using System.Collections.Generic;
        using System.IO;
        using System.Linq;
    
        class Program
        {
            static void Main(string[] args)
            {
                // Populate the dictionary 
                Dictionary<int, string> myDictionary = new Dictionary<int, string>();
                myDictionary.Add(1, "one");
                myDictionary.Add(2, "two");
                myDictionary.Add(3, "three");
    
                // Serialise it to disk
                string jsonToWrite = JsonConvert.SerializeObject(myDictionary);
                using (StreamWriter sw = File.CreateText("c:\\temp\\YourDictionary.txt"))
                {
                    sw.Write(jsonToWrite);
                }
    
                // Deserialise it from Disk back to a Dictionary
                string jsonToRead = File.ReadAllText("c:\\temp\\YourDictionary.txt");
                Dictionary<int, string> myDictionaryReconstructed =
                           JsonConvert.DeserializeObject<Dictionary<int, string>>(jsonToRead);
    
                // Check values exist in the two dictionaries
                if (myDictionary.All(x => myDictionaryReconstructed.Any(y => x.Value == y.Value)))
                {
                    Console.WriteLine("Success");
                }
                else
                {
                    Console.WriteLine("Failed");
                }
            }
        }
    }
