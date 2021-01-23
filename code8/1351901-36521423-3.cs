    static void Main(string[] args)
    {
        var textToSearch = "governor";
        var textToSearchIn = "In Boston in 1690, Benjamin Harris published Publick Occurrences Both Forreign and Domestick. This is considered the first newspaper in the American colonies even though only one edition was published before the paper was suppressed by the government. In 1704, the governor allowed The Boston News-Letter to be published and it became the first continuously published newspaper in the colonies. Soon after, weekly papers began publishing in New York and Philadelphia. These early newspapers followed the British format and were usually four pages long. They mostly carried news from Britain and content depended on the editor's interests. In 1783, the Pennsylvania Evening Post became the first American daily.";
        var pattern = String.Format("[^\\.]*\\b{0}\\b[^\\.]*", textToSearch);
        if (Regex.IsMatch(textToSearchIn, pattern))
        {
            foreach (var matchedItem in Regex.Matches(textToSearchIn, pattern))
            {
                Console.WriteLine(matchedItem);
                Console.WriteLine();
            }
        }
        var lastMatch = Regex.Matches(textToSearchIn, pattern).Cast<Match>().Last();
        Console.Read();
    }
