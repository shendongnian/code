        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.IO;
        namespace ConsoleApplication1
        {
           class Answer
          {
              static void Main(string[] args)
            {
              string text = "This text will appear on your console and be saved in the txt file";
                Console.WriteLine(text);
                StreamWriter saveText = new StreamWriter("YourTextFile.txt");
                saveText.WriteLine(text);
            
                saveText.Close();
                Console.ReadLine();
            }
          }
        }
