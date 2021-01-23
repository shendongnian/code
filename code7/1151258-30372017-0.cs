    string binary = "01001000";
    var list = new List<Byte>();
    for (int i = 0; i < binary.Length; i += 8)
    {
        if (binary.Length >= i + 8)
        {
            String t = binary.Substring(i, 8);
            list.Add(Convert.ToByte(t, 2));
        }
    }
    string result = Encoding.ASCII.GetString(list.ToArray());
