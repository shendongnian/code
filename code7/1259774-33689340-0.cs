    // on load form: fill the rich text box with
    // the complete works of William Shakespeare
    private async void Form1_Load(object sender, EventArgs e)
    {
        const string completeShakespeare = "http://www.gutenberg.org/cache/epub/100/pg100.txt";
        using (var downloader = new HttpClient())
        {
            this.richTextBox1.Text = await downloader.GetStringAsync (completeShakespeare);
        }
    }
    // on button click: mark all "thee" red
    private void button1_Click(object sender, EventArgs e)
    {
        var stopwatch = Stopwatch.StartNew();
        this.Colorize2("thee", Color.Red);
        var elapsed = stopwatch.Elapsed;
        Debug.WriteLine ("Coloring a text with {0} characters took {1:F3} sec",
            this.richTextBox1.Text.Length,
            elapsed.TotalSeconds);
    }
    private void Colorize2(string word, Color color)
    {
        string regString = String.Format(@"\b{0}\b", word);
        // regex: match substring that match word,
        // with boundaries to non alphanumeric characters like space and \n \r \t
        
        var regex = new Regex(regString, RegexOptions.IgnoreCase);
        var matches = regex.Matches(richTextBox1.Text);
        foreach (Match match in matches.Cast<Match>())
	    {
            this.richTextBox1.Select(match.Index, match.Length);
            this.richTextBox1.SelectionColor = color;
        }
    }
