    private string[] CommandSplitter(string text)
    {
        // strip /* ... */ comments
        var strip1 = Regex.Replace(text, SlashStarComment, " ", RegexOptions.Multiline);
        var strip2 = Regex.Replace(strip1, DashComment, "\n", RegexOptions.Multiline);
        // split into individual commands separated by '/'
        var commands = strip2.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
        return commands.Select(cmd => cmd.Split(new[] {'\n'})
            .Select(l => l.Trim()))
            .Select(lines => string.Join("\n", lines.Where(l => !string.IsNullOrWhiteSpace(l))))
            .ToArray();
    }
