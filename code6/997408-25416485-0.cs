    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication1
    {
    class Program
    {
        static void Main(string[] args)
        {
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            using (FileStream fs = File.Create("data.hffgfh"))
            {
                bf.Serialize(fs, 123456);
            }
        }
    }
    }
