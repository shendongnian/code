    List<char> chars = new List<char> ();
    List<string> names = new List<string>();
    List<string> types = new List<string>();
    List<string> paths = new List<string>();
    int index = 1;
    while (streamReader.Peek() >= 0)
    {
      char ch = (char)reader.Read();
      if (ch == '|')
      {
        switch(index)
        {
          case 1: names.Add( new String(chars.ToArray()));
          case 2: types.Add( new String(chars.ToArray()));
          case 3: paths.Add( new String(chars.ToArray()));
        }
        
        index = (index==3? 1: index+1);
        chars.Clear ();
        continue;
      }
      chars.Add(ch);
    }
