    var list = new List<string>
    {
         "50|Carbon|Mercury|P:4;P:00;P:1",
         "90|Oxygen|Mars|P:10;P:4;P:00",
         "90|Serium|Jupiter|P:4;P:16;P:10",
         "85|Hydrogen|Saturn|P:00;P:10;P:4"
    };
    int totalCount;
    var result = CountWords(list, "P:4", out totalCount);
    Console.WriteLine("Total Found: {0}", totalCount);
    foreach (var foundWords in result)
    {
        Console.WriteLine(foundWords);
    }
    public class FoundWords
    {
        public string LineNumber { get; set; }
        public int Found { get; set; }
    }
    private List<FoundWords> CountWords(List<string> words, string input, out int total)
    {
        total = 0;
        int[] index = {0};
        var result = new List<FoundWords>();
        foreach (var f in words.Select(word => new FoundWords {Found = Regex.Matches(word, input).Count, LineNumber = "Line Number: " + index[0] + 1}))
        {
            result.Add(f);
            total += f.Found;
            index[0]++;
        }
        return result;
    }
