    void SetSampleTextBlock(string[] words)
    {
        SampleTextBlock.Inlines.Clear();
        foreach (var word in words) 
        {
           var run = new Run { Text = word };
           if (word == "octopus") 
           {
              run.FontWeight = FontWeights.UltraBold;
           }
           SampleTextBlock.Inlines.Add(run);
        }
    }
