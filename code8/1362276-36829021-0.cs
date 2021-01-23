    int[] num = line.Select(c => (int)c).ToArray();
    string result =
        new StringBuilder()
            .Append("[")
            .Append(String.Join(", ", num.Select(n => n.ToString())))
            .Append("]")
            .ToString();
    Console.WriteLine(result);
