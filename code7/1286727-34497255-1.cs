    foreach (Match item in collection)
    {
        Run runRegularText = new Run();
        runRegularText.Text = tweet.Substring(index, item.Index);
        block.Inlines.Add(runRegularText);
        index = item.Index;
        Run runHyperlink = new Run();
        runHyperlink.Text = tweet.Substring(index, item.Length);
        Hyperlink h = new Hyperlink();
        h.Inlines.Add(runHyperlink);
        block.Inlines.Add(h);
        index = item.Index + item.Length;
    }
