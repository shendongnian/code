    private void UpdateRuns()
	{
		TextChanged -= MyRichTextBox_TextChanged;
		List<Run> runs = new List<Run>();
		foreach (Run run in Runs)
		{
			Run newRun;
			string value = run.Tag.ToString();
			if (Parameters.ContainsKey(value))
			{
				newRun = new Run(Parameters[value]);
			}
			else
			{
				newRun = new Run(value);
			}
			newRun.Background = run.Background;
			newRun.Foreground = run.Foreground;
			runs.Add(newRun);
		}
		Paragraph p = Document.Blocks.FirstBlock as Paragraph;
		p.Inlines.Clear();
		p.Inlines.AddRange(runs);
		TextChanged += MyRichTextBox_TextChanged;
	}
