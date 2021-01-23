    string input = "18th Jul 2016";
    string[] token = input.Split();  // split by space, result is a string[] with three tokens
    token[0] = new string(token[0].TakeWhile(char.IsDigit).ToArray());
    input = String.Join(" ", token);
    DateTime dt;
    if(DateTime.TryParseExact(input, "dd MMM yyyy", null, DateTimeStyles.None, out dt))
    {
        Console.WriteLine("Date is: " + dt.ToLongDateString());
    }
