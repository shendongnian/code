    public enum TokenType
    {
        Operator,
        Operand
    }
    public class Token
    {
        public string Value { get; set; }
        public TokenType Type { get; set; }
        public override string ToString()
        {
            return Type + "   " + Value;
        }
    }
    IEnumerable<Token> Parse(string input)
    {
        return Regex.Matches(input, @"(?<value>\d+)|(?<type>[\+\-\*\/\(\)])").Cast<Match>()
                    .Select(m => m.Groups["value"].Success
                            ? new Token() { Value = m.Groups["value"].Value, Type = TokenType.Operand }
                            : new Token() { Value = m.Groups["type"].Value, Type = TokenType.Operator });
    }
