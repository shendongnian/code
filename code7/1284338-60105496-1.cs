public static string AddLineBreaks(this string text, int maxLineLength, string indent = "\t")
{        
    // Strip off any whitespace (including \r) before each pre-existing end of line character.
    //
    text = Regex.Replace(text, @"\s+\n", "\n", RegexOptions.Multiline);
    // Matches that are too long include a trailing whitespace character (excluding newline)
    // which is then used to sense that an indent should occur
    // Regex to match whitespace except newline: https://stackoverflow.com/a/3469155/538763
    //
    string regex = @"(\n)|([^\n]{0," + maxLineLength + @"}(?!\S)[^\S\n]?)";
    return Regex.Replace(text, regex, m => m.Value +
        (m.Value.Length > 1 && Char.IsWhiteSpace(m.Value[m.Value.Length - 1]) ? ("\n" + indent) : ""));
}
[![enter image description here][1]][1]
  [1]: https://i.stack.imgur.com/CNZJA.png
