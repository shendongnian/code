    public class MorseCodeTranslationForm
    {
        private static readonly Dictionary<char, string> Translations =
            new Dictionary<char, string>
            {
                { 'A', ".-" },
                { 'B', "-..." },
                // etc 
            };
        // Normal constructor etc
        // Call this from an event handler...
        private static string ConvertToMorse(string text)
        {
            StringBuilder builder = new StringBuilder();
            foreach (char c in text)
            {
                string translated;
                if (Translations.TryGetValue(c, out translation))
                {
                    builder.Append(translated).Translate(' ');
                }
                else
                {
                    builder.Append(c); // Just leave it as it is                    
                }
            }
            return builder.ToString();
        }
    }
