    static HashSet<string> emojis = new HashSet<string>()
    {
        "grinning",
        "kissing_heart",
        "bouquet"
    };
    static string RemoveEmojis(string input)
    {
        StringBuilder sb = new StringBuilder();
        int length = input.Length;
        int startIndex = 0;
        int colonIndex = input.IndexOf(':');
        while (colonIndex >= 0 && startIndex < length)
        {
            //Keep normal text
            int substringLength = colonIndex - startIndex;
            if (substringLength > 0)
                sb.Append(input.Substring(startIndex, substringLength));
            //Advance the feed and get the next colon
            startIndex = colonIndex + 1;
            colonIndex = input.IndexOf(':', startIndex);
            if (colonIndex < 0) //No more colons, so no more emojis
            {
                //Don't forget that first colon we found
                sb.Append(':');
                //Add the rest of the text
                sb.Append(input.Substring(startIndex));
                break;
            }
            else //Possible emoji, let's check
            {
                string token = input.Substring(startIndex, colonIndex - startIndex);
                if (emojis.Contains(token)) //It's a match, so we skip this text
                {
                    //Advance the feed
                    startIndex = colonIndex + 1;
                    colonIndex = input.IndexOf(':', startIndex);
                }
                else //No match, so we keep the normal text
                {
                    //Don't forget the colon
                    sb.Append(':');
                    //Instead of doing another substring next loop, let's just use the one we already have
                    sb.Append(token);
                    startIndex = colonIndex;
                }
            }
        }
        return sb.ToString();
    }
    static void Main(string[] args)
    {
        List<string> inputs = new List<string>()
        {
            "Hello:grinning: , how are you?:kissing_heart: Are you fine?:bouquet:",
            "Tricky test:123:grinning:",
            "Hello:grinning: :imadethis:, how are you?:kissing_heart: Are you fine?:bouquet: This is:a:strange:thing :to type:, but valid :nonetheless:"
        };
        foreach (string input in inputs)
        {
            Console.WriteLine("In  <- " + input);
            Console.WriteLine("Out -> " + RemoveEmojis(input));
            Console.WriteLine();
        }
        Console.WriteLine("\r\n\r\nPress enter to exit...");
        Console.ReadLine();
    }
