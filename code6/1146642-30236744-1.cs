    public sealed class NumberStringComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return NumberString.Parse(x).CompareTo(NumberString.Parse(y));
        }
        private struct NumberString : IComparable<NumberString>
        {
            private readonly int? number;
            private readonly string text;
            private NumberString(int? number, string text)
            {
                this.number = number;
                this.text = text;
            }
            internal static NumberString Parse(string text)
            {
                // TODO: Find where the digits stop, parse the number
                // (if there is one), call the constructor and return a value.
                // (You could use a regular expression to separate the parts...)
            }
            public int CompareTo(NumberString other)
            {
                // TODO: Compare numbers; if they're equal, compare
                // strings
            }
        }
    }
