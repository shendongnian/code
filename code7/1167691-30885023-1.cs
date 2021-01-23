    public static void GetNumberOfTimesACharacterOccuredInAString(string text, int number)
    {
            Dictionary<char, int> CharactorNumberOfOccurence = new Dictionary<char, int>();
            int count = 1;
            foreach (char c in text.ToLower())
            {
                if (CharactorNumberOfOccurence.Any(a => a.Key.Equals(c)))
                {
                    count = CharactorNumberOfOccurence.Where(a => a.Key.Equals(c)).Select(a => a.Value).FirstOrDefault() + 1;
                    CharactorNumberOfOccurence.Remove(c);
                    CharactorNumberOfOccurence.Add(c, count);
                }
                else
                {
                    CharactorNumberOfOccurence.Add(c, count);
                }
            }
            foreach (KeyValuePair<char, int> charactor in CharactorNumberOfOccurence)
            {
                if (charactor.Value.Equals(number))
                {
                    if (char.IsWhiteSpace(charactor.Key))
                        Console.WriteLine("SPACE");
                    else
                        Console.WriteLine(charactor.Key.ToString().ToUpper());
                }
            }
    }
