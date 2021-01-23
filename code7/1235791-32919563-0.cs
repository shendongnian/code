    #region
    
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    
    #endregion
    
    namespace StringInFileTechchef
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                HashSet<WordCombo> existingWordCombos = GetWordCombos(File.ReadAllLines(@"C:\Users\Chiranjib\Desktop\F2.txt"));
                HashSet<WordCombo> newWordCombos = GetWordCombos(File.ReadAllLines(@"C:\Users\Ganesh\Chiranjib\F1.txt"));
    
                foreach (WordCombo newWordCombo in newWordCombos)
                {
                    existingWordCombos.Add(newWordCombo);
                }
    
                StringBuilder stringBuilder = new StringBuilder();
                foreach (WordCombo existingWordCombo in existingWordCombos)
                {
                    stringBuilder.AppendFormat("{0},{1}{2}", existingWordCombo.SmallerWord, existingWordCombo.BiggerWord, Environment.NewLine);
                }
    
                File.WriteAllText(@"C:\Users\Ganesh\Desktop\F2.txt", stringBuilder.ToString());
            }
    
            private static HashSet<WordCombo> GetWordCombos(IEnumerable<string> lines)
            {
                HashSet<WordCombo> wordCombos = new HashSet<WordCombo>();
                foreach (string line in lines)
                {
                    string[] splitWords = line.Split(new[] {','});
                    wordCombos.Add(new WordCombo(splitWords[0], splitWords[1]));
                }
    
                return wordCombos;
            }
    
            private class WordCombo
            {
                public string BiggerWord { get; private set; }
                public string SmallerWord { get; private set; }
    
                public WordCombo(string part1, string part2)
                {
                    if (0 < string.Compare(part1, part2, StringComparison.InvariantCultureIgnoreCase))
                    {
                        BiggerWord = part1;
                        SmallerWord = part2;
                    }
                    else
                    {
                        BiggerWord = part2;
                        SmallerWord = part1;
                    }
                }
    
                protected bool Equals(WordCombo other)
                {
                    return string.Equals(BiggerWord, other.BiggerWord, StringComparison.InvariantCultureIgnoreCase)
                           && string.Equals(SmallerWord, other.SmallerWord, StringComparison.InvariantCultureIgnoreCase);
                }
    
                public override bool Equals(object obj)
                {
                    if (ReferenceEquals(null, obj)) return false;
                    if (ReferenceEquals(this, obj)) return true;
                    if (obj.GetType() != GetType()) return false;
                    return Equals((WordCombo) obj);
                }
    
                public override int GetHashCode()
                {
                    unchecked
                    {
                        return ((BiggerWord != null ? BiggerWord.ToLowerInvariant().GetHashCode() : 0)*397) ^
                               (SmallerWord != null ? SmallerWord.ToLowerInvariant().GetHashCode() : 0);
                    }
                }
            }
        }
    }
