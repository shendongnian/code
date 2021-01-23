        Console.Writeline("Input file path");
        string input = Console.ReadLine();
        try{
          string[] lines = System.IO.File.ReadAllLines (@"C:\Users\Desktop\dictionary.txt");
          //The rest of your code here
        }catch{
           Console.Writeline("You did not input a valid path");
        }
