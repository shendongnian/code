    public class Example
    {
       public static void Main()
       {
          String value = "Action;Adventure;Drama;Horror";
          Char delimiter = ';';
          String[] substrings = value.Split(delimiter);
          foreach (var substring in substrings)
             Console.WriteLine(substring);
       }
    }
