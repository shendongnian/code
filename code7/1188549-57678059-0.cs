using System;
using System.IO.Compression;
namespace zipReader
{
    class Program
    {
        static void Main(string[] args)
        {
            ZipFile.ExtractToDirectory("C:\\Temp\\D20190827.exe", "C:\\Temp\\");
            Console.WriteLine("Extract Done!");
        }       
    }
}
