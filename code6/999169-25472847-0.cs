    internal class Program
    {
        private static void Main(string[] args)
        {
            string searchString =
                @"apple, orange, ""baboons, cows. dogs- hounds"", rainbow, ""unicorns, gummy bears"", abc, defghj";
            char delimeter = ',';
            char excludeSplittingWithin = '"';
            string[] splittedByExcludeSplittingWithin = searchString.Split(excludeSplittingWithin);
            List<string> splittedSearchString = new List<string>();
            for (int i = 0; i < splittedByExcludeSplittingWithin.Length; i++)
            {
                if (i == 0 || splittedByExcludeSplittingWithin[i].StartsWith(delimeter.ToString()))
                {
                    string[] splitttedByDelimeter = splittedByExcludeSplittingWithin[i].Split(delimeter);
                    for (int j = 0; j < splitttedByDelimeter.Length; j++)
                    {
                        splittedSearchString.Add(splitttedByDelimeter[j].Trim());
                    }
                }
                else
                {
                    splittedSearchString.Add(excludeSplittingWithin + splittedByExcludeSplittingWithin[i] +
                                             excludeSplittingWithin);
                }
            }
            foreach (string s in splittedSearchString)
            {
                if (s.Trim() != string.Empty)
                {
                    Console.WriteLine(s);
                }
            }
            Console.ReadKey();
        }
    }
