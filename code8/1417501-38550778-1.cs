    var paragraph = new Paragraph();
	
    foreach(...)
    {
        var run = new Run { Text = innerTextOfCell };
        if (InnerTextofCell == "TEXT")
        {
            run.FontWeight = FontWeights.Bold;
        }
    }
    
    paragraph.Inlines.Add(run);
    rtb2.Blocks.Add(paragraph);
