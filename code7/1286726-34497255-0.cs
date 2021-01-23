	Run run = new Run();
	run.Text = tweet.Substring(index , item.Index);
	//error occurs here.
	block.Inlines.Add(run);
	index = item.Index;
	run.Text = tweet.Substring(index , item.Length);
	Hyperlink h = new Hyperlink();
	h.Inlines.Add(run);
	block.Inlines.Add(h);
	index = item.Index + item.Length;
