    public static String FmtString(string token, string unit, double value, string desc){
        bool isNumber = Double.TryParse(value, out num);
        string[] valueNumber = value.ToString(
            CultureInfo.CurrentCulture.NumberFormat
            .NumberDecimalSeparator)
            .Split('.');
        int lpad = 11 - valueNumber[0].Length;
        int rpad = 19 - valueNumber[1].Length;
        string output = String.Format("{0}{1}.{2}{3}",
            new String(' ', lpad),
            valueNumber[0],
            valueNumber[1],
            new string(' ', rpad));
        return string.Format(" {0,-4}.{1,-4}{2}  :  {3,-25}\n",
            token, unit, output, desc);
    }
