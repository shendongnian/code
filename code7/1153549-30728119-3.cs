    public class Program
    {
        //hashset for in memory representation of emoji,
        //lookups are O(1), so very fast
        private HashSet<string> _emoji = null;
        public Program(IEnumerable<string> emojiFromDb)
        {
            //load emoji from datastore (db/file,etc)
            //into memory at startup
            _emoji = new HashSet<string>(emojiFromDb);
        }
        
        public string RemoveEmoji(string input)
        {
            //pattern to search for
            string pattern = @":(\w*):";
            string output = input;
            //use regex to find all potential patterns in the input
            MatchCollection matches = Regex.Matches(input, pattern);
            //only do this if we actually find the 
            //pattern in the input string...
            if (matches.Count > 0)
            {
                //refine this to a distinct list of unique patterns 
                IEnumerable<string> distinct = 
                    matches.Cast<Match>().Select(m => m.Value).Distinct();
                //then check each one against the hashset, only removing
                //registered emoji. This allows non-emoji versions 
                //of the pattern to survive...
                foreach (string match in distinct)
                    if (_emoji.Contains(match))
                        output = output.Replace(match, string.Empty);
            }
            return output;
        }
    }
    public class MainClass
    {
        static void Main(string[] args)
        {
            var program = new Program(new string[] { ":grinning:", ":kissing_heart:", ":bouquet:" });
            string output = program.RemoveEmoji("Hello:grinning: :imadethis:, how are you?:kissing_heart: Are you fine?:bouquet: This is:a:strange:thing :to type:, but valid :nonetheless:");
            Console.WriteLine(output);
        }
    }
