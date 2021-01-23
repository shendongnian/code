    using System;
    using System.IO;
    using Newtonsoft.Json;
    
    class Test
    {
        static void Main()
        {
            var json = File.ReadAllText("test.json");
            string[][] array = JsonConvert.DeserializeObject<string[][]>(json);
            Console.WriteLine(array[1][3]); // FirstValue4
        }
    }
