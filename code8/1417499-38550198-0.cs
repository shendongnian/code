    if (InnerTextofCell == "TEXT")
    {
       rtb2.Blocks.Add(new Paragraph (new Run { FontWeight = FontWeights.Bold, Text = innerTextOfCell }));
    }
    else
    {
       rtb2.Blocks.Add(new Paragraph (new Run { FontWeight = FontWeights.Normal, Text = innerTextOfCell }));
    }
