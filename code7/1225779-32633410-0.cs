    public string GetCommonStart(string a, string b)
    {
      if ((a == null) || (b == null))
        throw new ArgumentNullException();
      int Delim = 0;
      int I = 0;
      while ((I < a.Length) && (I < b.Length) && (a[I] == b[I]))
      {
        if (a[I++] == Path.AltDirectorySeparatorChar) // or Path.DirectorySeparatorChar
          Delim = I;
      }
      return a.Substring(0, Delim);
    }
