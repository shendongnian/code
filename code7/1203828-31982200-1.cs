    List<string> input = new List<string> { "first", "second" };
    StringBuilder sb = new StringBuilder();
    foreach (string s in input )
        sb.Append(s);
    byte[] byteArray = Encoding.UTF8.GetBytes(sb.ToString());
