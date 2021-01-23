    try
    {
    ...
    }
    catch (Exception e)
    {
      Console.WriteLine(e.ToString());
      Thread.Sleep(5000);
      string[] argv = { };
      Main(argv);
    }
    finally 
    {
      //Close all streams
      writer?.Close();
      reader?.Close();
      irc?.Close();
    }
