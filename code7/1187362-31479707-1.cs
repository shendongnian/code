    string input = "CityABCProcess TEST";
    StringBuilder builder = new StringBuilder();
    builder.Append("[A-Z][a-z]+");
    builder.Append("|");
    builder.Append("[A-Z]+$");
    builder.Append("|");
    builder.Append("[A-Z]+(?=[A-Z])");
    builder.Append("|");
    builder.Append("[a-z]+");
    foreach (Match m in Regex.Matches(input, builder.ToString()))
        {
        Console.WriteLine(m.Value);
        }
