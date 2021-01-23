    private static void AppendImageArgs(string serviceName, IEnumerable<Tuple<string, object>> args)
    {
      try
      {
        using (var service = Registry.LocalMachine.OpenSubKey($@"System\CurrentControlSet\Services\{serviceName}", true))
        {
          const string imagePath = "ImagePath";
          var value = service?.GetValue(imagePath) as string;
          if (value == null)
            return;
          foreach (var arg in args)
            if (arg.Item2 == null)
              value += $" -{arg.Item1}";
            else
              value += $" -{arg.Item1} \"{arg.Item2}\"";
          service.SetValue(imagePath, value);
        }
      }
      catch (Exception e)
      {
        Log.Error(e);
      }
    }
