    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    namespace ABCD
    {
        class Program
        {
            static void Main(string[] args)
            {
                while (true)
                {
                    Console.WriteLine(">Enter File to open.");//Prompt user for file name
                    string fileName = Console.ReadLine();
                    try
                    {
                        if (!File.Exists(fileName))
                            throw new FileNotFoundException();//Check for errors
                        else
                            System.Diagnostics.Process.Start(fileName); //set valid reply response
    
                        Console.ReadLine();
                    }
                    catch (FileNotFoundException)
                    {
                        Console.WriteLine("You stuffed up!"); //Display error message
                    }
                }
            }
        }
    }
