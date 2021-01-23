    static void Main()
    {
        var defaultRegexOptions = RegexOptions.CultureInvariant | RegexOptions.ExplicitCapture | RegexOptions.Singleline;
        var regex1 = new Regex(@"^[A-Za-z]+$", defaultRegexOptions);
        var regex2 = new Regex(@"^[A-Za-z]+$", defaultRegexOptions | RegexOptions.IgnoreCase);
        ParallelEnumerable.Range(char.MinValue, char.MaxValue - char.MinValue + 1)
            .ForAll(firstCharAsInt =>
            {
                var buffer = new char[2];
                buffer[0] = (char)firstCharAsInt;
    
                for (int i = char.MinValue; i <= char.MaxValue; i++)
                {
                    buffer[1] = (char)i;
    
                    var str = new string(buffer);
    
                    if (regex1.IsMatch(str) != regex2.IsMatch(str))
                        Console.WriteLine("dfjkgnearjkgh");
                }
            });
    }
