    public string ZeroPoint(string a)
    {
      int pos = a.IndexOf(".");
      if (pos > -1 && a.Substring(0, pos) == new string('0', pos))
      {
        a = "0" + a.Substring(pos, a.Length - pos);
      }
      return a;
    }
