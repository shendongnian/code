    static void MyHandler(object sendingProcess, DataReceivedEventArgs output)
    {
      if (!String.IsNullOrEmpty(output.Data))
      {
        Console.WriteLine(output.Data); // or whatever
      }
    }
