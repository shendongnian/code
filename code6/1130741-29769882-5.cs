    private static string CheckValid(string path)
    {
      if(path.Length == 0)
        return "You cannot enter an empty file path";
      switch(path[path.Length - 1])
      {
        case '\\':
        case '/':
          return "You cannot enter a directory path";
      }
      return null;
    }
    public static void Main(string[] args)
    {
      Console.WriteLine("Enter a file path");
      var path = Console.ReadLine().Trim();
      var validationError = CheckValid(path);
      if(validationError != null)
        Console.Error.WriteLine(validationError);
      else
      {
        try
        {
          using(var reader = new StreamReader(path))
            Console.WriteLine(reader.ReadToEnd());
        }
        catch(FileNotFoundException)
        {
          Console.Error.WriteLine("File not found");
        }
        catch(UnauthorizedAccessException)
        {
          Console.Error.WriteLine("Access denied");
        }
        catch(IOException ioe)
        {
          Console.Error.WriteLine(string.Format("I/O Exception: {0}", ioe.Message));
        }
      }
      Console.Read();
    }
