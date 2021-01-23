    public static void Output<T>(T data)
    {
      var formats = new Dictionary<Type, string>
      {
        {typeof (Double), "{0:N4}"}
      };
      var format = formats.Where(x => x.Key == typeof(T))
                          .Select(x => x.Value).SingleOrDefault();
      string dataStr = data.ToString();
      if (format != null)
        dataStr = String.Format(format, data);
      Console.WriteLine(dataStr);
    }
