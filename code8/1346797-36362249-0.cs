    private readonly static Regex regex = new Regex("%(?<name>.+?)%");
    private static string Replace(string input, ISet<string> replacements)
    {
        string result = regex.Replace(input, m => {
            
            string name = m.Groups["name"].Value;
            string value;
            if (replacements.Contains(name))
            {
                return GetValueByPlaceholder(name);
            }
            else   
            {
                return m.Captures[0].Value;
            }
        });
        
        return result;
    }
    public static void Main(string[] args)
    {
        var replacements = new HashSet<string>(StringComparer.CurrentCultureIgnoreCase)
        {
            "EmailSender", "ErrorMessage", "ActiveUser"
        };
        
        string text = "Hello %ACTIVEUSER%, There is a message from %emailsender%. %errorMessage%";
        string result = Replace(text, replacements);
        
        Console.WriteLine(result);
    }
