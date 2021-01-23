    class Program
    {
        static void Main(string[] args)
        {
            var text = "47-62**5141";
            var splittedText = text.SplitAndKeepSeparator('-', '*');
            foreach (var part in splittedText)
            {
                Console.WriteLine(part);
            }
            Console.ReadLine();
        }
    }
    public static class StringExtensions
    {
        public static IEnumerable<string> SplitAndKeepSeparator(this string s, params char[] seperators)
        {
            var parts = s.Split(seperators, StringSplitOptions.None);
            var partIndex = 0;
            var isPart = true;
            var indexInText = 0;
            while (partIndex < parts.Length)
            {
                if (isPart)
                {
                    var partToReturn = parts[partIndex];
                    if (string.IsNullOrEmpty(partToReturn))
                    {
                        partToReturn = s[indexInText].ToString();
                    }
                    else
                    {
                        isPart = false;
                    }
                    indexInText += partToReturn.Length;
                    partIndex++;
                    yield return partToReturn;
                }
                else
                {
                    var currentSeparator = s[indexInText];
                    indexInText++;
                    isPart = true;
                    yield return currentSeparator.ToString();
                }
            }
        }
