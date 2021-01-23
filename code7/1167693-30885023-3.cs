    public static void GetNumberOfTimesACharacterOccuredInAString(string text, int number)
    {
                List<char> result = text.GroupBy(x => x).Where(y => y.Count() == number).Select(y => y.Key).ToList();
    
                foreach (char c in result)
                {
                    if (char.IsWhiteSpace(c))
                    {
                        Console.WriteLine("SPACE");
                    }
                    else
                    {
                        Console.WriteLine(c.ToString());
                    }
                }
     }
