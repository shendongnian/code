    public class LowerNamingConvention : INamingConvention
    {
        public Regex SplittingExpression
        {
            get { return new Regex(@"[\p{Ll}0-9]+(?=$|\p{Lu}[\p{Ll}0-9])|\p{Lu}?[\p{Ll}0-9]+)"); }
        }
        public string SeparatorCharacter
        {
            get { return string.Empty; }
        }
    }
