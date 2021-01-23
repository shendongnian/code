    // Parse a list of tokens from Lex()
    static void Parse(List<string> tokens)
    {
        // Run through each token in the list of tokens
        for (int i = 0; i < tokens.Count; i++)
        {
            // And act on the token
            switch (tokens[i])
            {
                case "PRINT":
                    // PRINT prints the next token
                    // Move to the next token first
                    i++;
                    // And dump it out
                    Console.WriteLine(tokens[i]);
                    break;
                default:
                    // Anything else is an error, so emit an error
                    Console.WriteLine("ERROR: Unknown token " + tokens[i]);
                    break;
            }
        }
    }
    // Parse a source code file, returning a list of tokens
    static List<string> Lex(string data)
    {
        // The current token we're building up
        string current = "";
        // Are we inside of a quoted string?
        bool inQuote = false;
        // The list of tokens to return
        List<string> tokens = new List<string>();
        foreach (char c in data)
        {
            if (inQuote)
            {
                switch (c)
                {
                    case '"':
                        // The string literal has ended, go ahead and note 
                        // we're no longer in quote
                        inQuote = false;
                        break;
                    default:
                        // Anything else gets added to the current token
                        current += c;
                        break;
                }
            }
            else
            {
                switch (c)
                {
                    case '"':
                        // This is the start of a string literal, note that
                        // we're in it and move on
                        inQuote = true;
                        break;
                    case ' ':
                    case '\n':
                    case '\r':
                    case '\t':
                        // Tokens are sperated by whitespace, so any whitespace
                        // causes the current token to be added to the list of tokens
                        if (current.Length > 0)
                        {
                            // Only add tokens
                            tokens.Add(current);
                            current = "";
                        }
                        break;
                    default:
                        // Anything else is part of a token, just add it
                        current += c;
                        break;
                }
            }
        }
        return tokens;
    }
    // Quick demo
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        string data = File.ReadAllText(input);
        List<string> tokens = Lex(data);
        Parse(tokens);
        Console.ReadLine();
    }
