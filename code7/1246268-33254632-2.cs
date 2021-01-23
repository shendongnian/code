    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    
    internal class Program
    {
      private static void Main()
      {
        var cultureLithunia = new CultureInfo("lt-LT");
        var textInfoLithunia = cultureLithunia.TextInfo;
    
        string requested = textInfoLithunia.ToUpper("AĄBCČDEĘĖFGHIĮYJKLMNOPRSŠTUŲŪVZŽ");
    
        string content = File.ReadAllText("failas.txt", Encoding.GetEncoding(textInfoLithunia.ANSICodePage));
    
        var characters = content.GroupBy(c => c);
    
        var charactersYouWant = requested.Select(c => new { Key = c, Count = characters.Where(cc => textInfoLithunia.ToUpper(cc.Key) == c).Select(group => group.Count()).FirstOrDefault() });
    
        var linesYouWantToOutput = charactersYouWant.Select(c => string.Format("Character {0}, No of Occurences = {1}", c.Key, c.Count));
    
        File.WriteAllLines("rezultatai.txt", linesYouWantToOutput);
        
        Console.WriteLine("Done");
        Console.ReadKey();
      }
    }
