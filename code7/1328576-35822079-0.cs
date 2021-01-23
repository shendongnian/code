    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace BinarySerializerSample
    {
        class Program
        {
            public static void WriteValues(string fName, double[] vals)
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(fName, FileMode.Create)))
                {
                   int len = vals.Length;
                   for (int i = 0; i < len; i++)
                       writer.Write(vals[i]);
                }
            }
            public static double[] ReadValues(string fName, int len)
            {
                double [] vals = new double[len];
                using (BinaryReader reader = new BinaryReader(File.Open(fName, FileMode.Open)))
                {
    
                    for (int i = 0; i < len; i++)
                        vals[i] = reader.ReadDouble();
                }
                return vals;
            }
    
            static void Main(string[] args)
            {
                const double MAX_TO_VARY = 100.0;
                const int NUM_ITEMS = 100;
                const string FILE_NAME = "dblToTestx.bin";
                double[] dblToWrite = new double[NUM_ITEMS];
                Random r = new Random();
                for (int i = 0; i < NUM_ITEMS; i++)
                    dblToWrite[i] = r.NextDouble() * MAX_TO_VARY;
    
                WriteValues(FILE_NAME, dblToWrite);
    
                double[] dblToRead ;
                dblToRead = ReadValues(FILE_NAME, NUM_ITEMS);
               
                int j = 0;
                bool areEqual = true;
                while (areEqual && j < NUM_ITEMS)
                {
    
                    areEqual = dblToRead[j] == dblToWrite[j];
                    ++j;
                }
                if (areEqual)
                    Console.WriteLine("Test Passed: Press any Key to Exit");
                else
                    Console.WriteLine("Test Failed: Press any Key to Exit");
                Console.Read();
    
            }
        }
    }
