    public static decimal DecimalParse(string number)
    {
        if (new Regex(@"^\d+$").IsMatch(number))
        {
            return decimal.Parse(number, CultureInfo.InvariantCulture);
        }
        if (new Regex(@"^(\d{0,3}(,\d{3})*(\.\d+)?)$").IsMatch(number))
        {
            return decimal.Parse(number, CultureInfo.InvariantCulture);
        }
        return new Regex(@"^(\d{0,3}(\.\d{3})*(,\d+)?)$").IsMatch(number)
            ? decimal.Parse(number.Replace(".", "").Replace(",", "."), CultureInfo.InvariantCulture)
            : 0;
    }
