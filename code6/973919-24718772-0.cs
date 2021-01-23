    static void Main(string[] args)
    {
        var arg0 = (string)"fred";
        var arg1 = (int)50;
        var format = "{0}";
        var result = Format(format, arg0, arg1);
        for(int index = 0; index < result.Arguments.Length; index++)
        {
            if(String.IsNullOrEmpty(result.Arguments[index].Capture))
            {
                Console.WriteLine(
                    "Argument {0} with value {1} was unused", 
                    index, result.Arguments[index].Value);
            }
            else
            {
                Console.WriteLine(
                    "Argument {0} with value {1} was used, starting at index {2}", 
                    index, result.Arguments[index].Value,
                    result.Arguments[index].Index);
            }
        }
    }
    static Transformation Format(string format, params object[] args)
    {
        var value = new Transformation
        {
            Format    = format,
            Arguments = (args ?? new object[]{})
                .Select (o => new Argument{ Value = o })
                .ToArray()
        };
        value.Result = Regex.Replace(format, @"{(\d+)}", (match) =>
        {
            int index = Convert.ToInt32(match.Groups[1].Value);
            if (index > args.Length) return "";
            var @this = args[index];
            var result = @this == null ? "" : @this.ToString();
                
            value.Arguments[index].Index   = match.Index;
            value.Arguments[index].Capture = match.Value;
            value.Arguments[index].Length  = result.Length;
            return result;
        });
        return value;
    }
    class Transformation
    {
        public string Format        { get; set; }
        public string Result        { get; set; }
        public Argument[] Arguments { get; set; }
    }
    class Argument
    {
        public object Value         { get; set; }
        public int Index            { get; set; }
        public int Length           { get; set; }
        public string Capture       { get; set; }
    }
