    public static decimal DecimalParse(string number)
    {
        if (new Regex(@"^(\d{0,3}(,\d{3})*(\.\d+)?)$").IsMatch(number))
        {
            return decimal.Parse(number);
        }
        return new Regex(@"^(\d{0,3}(\.\d{3})*(,\d+)?)$").IsMatch(number)
            ? decimal.Parse(number.Replace(".", "").Replace(",", "."))
            : 0;
    }
