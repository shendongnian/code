        private string ReplaceSeparator(string Num)
        {
            return Num.Replace(",", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator).Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
        }
        .....
    string first = "23.3";
    string second = "23,3";
    first = ReplaceSeparator(first);
    second = ReplaceSeparator(second);
            
    double number = double.Parse(first);
    double another = double.Parse(second);
