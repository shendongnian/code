        Console.Writeline("Input file path");
        string input = Console.ReadLine();
        try{
          string[] lines = System.IO.File.ReadAllLines (input);
          //The rest of your code here
        }catch{
           Console.Writeline("You did not input a valid path");
        }
