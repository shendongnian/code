     public enum SortColumnType
     {
            Numeric=1,
            String=2
     }
    public class NumberTextComparer : IComparer<string>
        {
            public SortColumnType ColumnType { get; set; }
     
            public NumberTextComparer(SortColumnType columnType)
            {
                ColumnType = columnType;
            }
     
            private int CustomNumberSort(string s1, string s2)
            {
                double number1, number2;
                var isS1Numeric = double.TryParse(s1, out number1);
                var isS2Numeric = double.TryParse(s2, out number2);
     
                if (isS1Numeric && isS2Numeric)
                {
                    if (number1 > number2) return 1;
                    if (number1 < number2) return -1;
                    return 0;
                }
                if (isS1Numeric)
                    return 1;
                if (isS2Numeric)
                    return -1;
     
                var s1StartsWithLetter = !string.IsNullOrEmpty(s1) && char.IsLetterOrDigit(s1[0]);
                var s2StartsWithLetter = !string.IsNullOrEmpty(s2) && char.IsLetterOrDigit(s2[0]);
     
                if (s1StartsWithLetter == s2StartsWithLetter)
                    return String.Compare(s1, s2, StringComparison.OrdinalIgnoreCase);
                if (s1StartsWithLetter)
                    return -1;
                return 1;
            }
     
            public int Compare(string s1, string s2)
            {
                return ColumnType.Equals(SortColumnType.Numeric)
                    ? CustomNumberSort(s1, s2)
                    : String.Compare(s1, s2, StringComparison.OrdinalIgnoreCase);
            }
        }
     
    stringList.OrderBy(str => str, new NumberTextComparer(SortColumnType.String));
    numericList.OrderBy(str => str, new NumberTextComparer(SortColumnType.Numeric));
