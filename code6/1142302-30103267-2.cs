        public static string FixDecimal(string input) {
            var bad = Regex.Match(input, @"^-?((?<bad>[^\d\.,])|\d)*([\.,](\d|(?<bad>\D+))*)?$").Groups["bad"];
            if (bad.Success) {
                return FixDecimal(input.Remove(bad.Index, bad.Length));
            } else {
                return input;
            }
        }
