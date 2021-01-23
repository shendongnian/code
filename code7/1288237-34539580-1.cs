    using System.Text.RegularExpressions;
    private void Form1_Load(object sender, EventArgs e)
    {
        var textBox = new TextBox
        {
            Multiline = true,
            WordWrap = false,
            Width = 295,
            Height = 100,
            ReadOnly = true
        };
        var textFromDatabase = "1234567890 1234567890 1234567890 1234567890 111150dasdasds1234567890 1234567890 1234567890 1234567890 111150dasdasds1234567890 1234567890 1234567890 1234567890 1111";
        var strings = Regex.Matches(textFromDatabase, ".{0,50}");
        var lines = strings.Cast<Match>()
                           .Select(m => m.Value)
                           .Where(m => !string.IsNullOrWhiteSpace(m));
        var @join = string.Join(Environment.NewLine, lines);
        textBox.Text = @join;
        Controls.Add(textBox);
    }
