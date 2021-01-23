    String str ="1.00";
    str = str.Replace(@"""", @"\""");
    str = str.Replace("\"", "\\\"");
    if (Double.TryParse(str, out i))
    {
        Console.WriteLine(Convert.ToInt32(i));
    }
