    string stuff = "AD 123 (+45) AS 6.7(+8%)";
    List<double> numbers = new List<double>();
    int numberStart = -1;
    for (int i = 0; i < stuff.Length; i++)
    {
        if (char.IsDigit(stuff[i])
            || stuff[i].ToString() == CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)
        {
            if (numberStart == -1)
            {
                numberStart = i;
            }
        }
        else
        {
            if (numberStart != -1)
            {
                numbers.Add(double.Parse(stuff.Substring(numberStart, i - numberStart)));
            }
            numberStart = -1;
        }
    }
    if (numberStart != -1) numbers.Add(double.Parse(stuff.Substring(numberStart)));
    Console.WriteLine(string.Join(",", numbers));
