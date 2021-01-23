    public void AddLog (string message, string fn_name)
    {
        string path = @"E:\" + fn_name +".txt";
        using(var tw = new StreamWriter(path, true))
        {
          tw.WriteLine(message);
        }
    }
