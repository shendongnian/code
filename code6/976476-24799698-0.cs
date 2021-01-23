        public sealed class SubstringFormatter : ICustomFormatter, IFormatProvider
    {
        private readonly static Regex regex = new Regex(@"(\d+),(\d+)", RegexOptions.Compiled);
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            Match match = regex.Match(format);
            if (!match.Success)
            {
                throw new FormatException("The format is not recognized: " + format);
            }
            if (arg == null)
            {
                return string.Empty;
            }
            int startIndex = int.Parse(match.Groups[1].Value);
            int length = int.Parse(match.Groups[2].Value);
            return arg.ToString().Substring(startIndex, length);
        }
        public object GetFormat(Type formatType)
        {
            return formatType == typeof(ICustomFormatter) ? this : null;
        }
    }
