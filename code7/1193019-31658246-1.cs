    string input = "20 * (6+3) / ((4+6)*9)";
    Console.WriteLine(input);
    DataTable dt = new DataTable();
    Regex rx = new Regex(@"\([^()]*\)");
    string expression = input;
    while (rx.IsMatch(expression))
    {
    	expression = rx.Replace(expression, m => dt.Compute(m.Value, null).ToString(), 1);
    	Console.WriteLine(expression);
    }
    Console.WriteLine(dt.Compute(expression, null));
