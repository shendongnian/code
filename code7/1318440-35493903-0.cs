    namespace myVocabulary
    {
        class Program
        {
            static List<Word> vocabulary = new List<Word>();
            static void Main(string[] args)
            {
                for (int i = 0; i < 5; i++)
                {
                    Word entry = new Word();
                    Console.WriteLine("Enter word");
                    entry.Original_Word = Console.ReadLine();
                    Console.WriteLine("Enter Translation");
                    entry.Translated_Word = Console.ReadLine();
                    vocabulary.Add(entry);
                }           
            }
        }
    }
