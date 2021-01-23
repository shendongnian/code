        double[] numbers1 = 
            lineStr1.Replace(",", ".")
                        .Split(new char[0], StringSplitOptions.RemoveEmptyEntries)
                        .Select(s =>
                        {
                            double value;
                            bool success = double.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out value);
                            return new { value, success };
                        })
                        .Where(p => p.success)
                        .Select(p => p.value)
                        .ToArray();
        double[] numbers2 = 
            lineStr2.Replace(",", ".")
                        .Split(new char[0], StringSplitOptions.RemoveEmptyEntries)
                        .Select(s =>
                        {
                            double value;
                            bool success = double.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out value);
                            return new { value, success };
                        })
                        .Where(p => p.success)
                        .Select(p => p.value)
                        .ToArray();
