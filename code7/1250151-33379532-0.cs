    using System;
    using System.Text;
    using System.IO;
    
    class Program {
        static void Main(string[] args) {
            var big = new StringBuilder(1600 * 1000);
            big.Append('0', big.Capacity);
            var sw = System.Diagnostics.Stopwatch.StartNew();
            // Your code here
            FileStream fs1 = new FileStream("BigInteger.txt",  FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(fs1);
            writer.WriteLine(big);
            writer.Close();
            // End of your code
            sw.Stop();
            Console.WriteLine("That took {0} milliseconds", sw.ElapsedMilliseconds);
            Console.ReadLine();
        }
    }
