    var elString = element.ToString();
    var buffer = new StringBuilder(element.Length - 2); //Can't be larger, unlikely to be much smaller so obtain necessary space in advance.
    using(var en = elString.Split().GetEnumerator())
    {
      int count = 0;
      while(en.MoveNext() && ++count != 4)
        buffer.Append(en.Current);
      while(en.MoveNext())
        buffer.Append(en.Current).Append(' ');
    }
    string joined = buffer.ToString();
