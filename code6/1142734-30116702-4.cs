    // export numbers
    string input = "+3% price per day(+60% price at day 20)";
    int[] array = Regex.Matches(input, @"\d+").OfType<Match>().Select(e => int.Parse(e.Value)).ToArray();
    // replace numbers
    double k = 3;
    string replaced = Regex.Replace(input, @"\d+", e => (int.Parse(e.Value) * k).ToString());
    // replace only percents
    k = 4;
    string replacedPercents = Regex.Replace(input, @"(\d+)%", e => (int.Parse(e.Groups[1].Value) * k).ToString() + "%");
    // floating conversion
    input = "+0.87 price per day(+63.00 price at day 20)";
    string replacedFloating = Regex.Replace(input, @"\+(\d+\.(\d+)|\d+)", e => "+" + (double.Parse(e.Groups[1].Value, CultureInfo.InvariantCulture) * k).ToString(e.Groups[2].Length == 0 ? "0" : "0." + new string('0', e.Groups[2].Length), CultureInfo.InvariantCulture));
    // floating conversion with negatives
    input = "-0.87 price per day(+63.00 price at day 20)";
    string replacedFloatingNegative = Regex.Replace(input, @"([+-])(\d+\.(\d+)|\d+)", e => e.Groups[1].Value + (double.Parse(e.Groups[2].Value, CultureInfo.InvariantCulture) * k).ToString(e.Groups[3].Length == 0 ? "0" : "0." + new string('0', e.Groups[3].Length), CultureInfo.InvariantCulture));
