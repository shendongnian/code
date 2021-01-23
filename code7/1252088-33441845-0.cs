    using System;
    using System.IO;
    namespace ConsoleApplication1
    {
         class ReadFromFile
         {
             static void Main()
             {
                 Console.WriteLine("Welcome to Decrypter (Press any key to       begin)");
                 Console.ReadKey();
                 //User selects file they wish to decrypt
                 int counter = 0;
                 string line;
                 string path = "";
                 try
                 {
                     while (true)
                     {
                         if (!File.Exists(path))
                         {
                             Console.WriteLine("\nPlease type the path to your file");
                             path = Console.ReadLine();
                         }
                         else
                         {
                             // Read the file and display it line by line.
                             System.IO.StreamReader file =
                                 new System.IO.StreamReader(path);
                             while ((line = file.ReadLine()) != null)
                             {
                                 Console.WriteLine(line);
                                 counter++;
                             }
                             file.Close();
                             break;
                         }
                     }
                 }
                 catch (Exception)
                 {
                     Console.WriteLine("The value you entered is incorrect.");
                 }
             }
         }
      }
    ​
