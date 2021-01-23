    using System.Text.RegularExpressions;
    using System.Linq;
    using System.Windows.Forms;
    private static List<string[]> parseString(string input)
    {
        var pattern = @"Start\s+Date:\s+([0-9-]+)\s+End\s+Date:\s+([0-9-]+)\s+(?:Warranty\s+Type:\s+\w+\s+)?Status:\s+(\w+)\s*";
        return Regex.Matches(input, pattern).Cast<Match>().ToList().ConvertAll(m => new string[] { m.Groups[1].Value, m.Groups[2].Value, m.Groups[3].Value });
    }
    // To show the result string
    var result1 = parseString(str1);
    string result_string = string.Join("\n", result1.ConvertAll(r => string.Format("Start Date: {0}\nEnd Date: {1}\nStatus: {2}", r)).ToArray());
    MessageBox.Show(result_string);
