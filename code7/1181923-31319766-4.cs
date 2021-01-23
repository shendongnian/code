      public voidConvertToString(ListView l, string dbString)
      {
         string [] sep = {"\r\n"};
         foreach (string item in dbString.Split(sep, StringSplitOptions.None))
            l.Items.Add(item);
      }
