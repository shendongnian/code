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
            //use regex to find all potential patterns, then
            //check each one against the hashset, only remove
            //registered emoji. This allows non-emoji versions 
            //of the pattern to survive...
            MatchCollection matches = Regex.Matches(input, pattern);
            foreach (Match match in matches)
                if (_emoji.Contains(match.Value))
                    output = output.Replace(match.Value, string.Empty);
            return output;
        }
    }
