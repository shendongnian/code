    using System.Linq;
    
    public class Test
    {
        static void Main(string[] args)
        {
            string patternWord = Console.ReadLine();
            string inputSentence = Console.ReadLine();
            var words = GetWords(inputSentence);
            var count = words.Count(word => string.Equals(patternWord, word, StringComparison.InvariantCultureIgnoreCase));
            Console.WriteLine(count);
            Console.ReadLine();
        }
    
        private static IEnumerable<string> GetWords(string sentence)
        {
            while (!string.IsNullOrEmpty(sentence))
            {
                var word = new string(sentence.TakeWhile(Char.IsLetterOrDigit).ToArray());
                yield return word;
                sentence = new string(sentence.Skip(word.Length).SkipWhile(c => !Char.IsLetterOrDigit(c)).ToArray());
            }
        }
    }
