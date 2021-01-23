    int[] num = line.Select(c => (int)c).ToArray();
    string result =
        new StringBuilder()
            .Append("[")
            .Append(String.Join(" ", num.Select(n => String.Format("{0},", n))))
            .Append("]")
            .ToString();
    Console.WriteLine(result);
