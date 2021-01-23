    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Diagnostics;
    using System.IO;
    namespace Bitch
    {
    class Program
    {
    static void Main(string[] args)
    {
        Console.WriteLine("Type Help If You Need More Info:");
        string input = Console.ReadLine(); // Only ask for input once not 3 times!
        if(input == "UneedPassMate")
        {
            System.Diagnostics.Process.Start("chrome.exe");
            System.Environment.Exit(0);
        }
        if(input == "Help")
        {
            Console.WriteLine("To Open Chrome\n You Will Need To Enter A Password>");
            Console.ReadLine();
        }
        if (input == "help")
        {
            Console.WriteLine("To Open Chrome\n You Will Need To Enter A Password>");
            Console.ReadLine();
        }
    }
    }
    }
