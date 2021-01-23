    int[] numbers =
        line
            .Split(' ')
            .Select(number => Int32.Parse(number))
            .ToArray();
    string result =
        new StringBuilder()
            .Append("[")
            .Append(
                String.Join(
                    " ",
                    numbers.Select(number => String.Format("{0},", number))
                )
            )
            .Append("]")
            .ToString();
    Console.WriteLine(result);
