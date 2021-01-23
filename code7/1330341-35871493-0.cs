    private void CreateLabelsForTesting(GroupBox grpBoxInstructions)
    {
        int x = 0;
        int y = 0;
        foreach (KeyValuePair<string, string> labels in LabelTexts)
        {
            Label l = new Label();
            l.Name = labels.Key;
            l.Text = labels.Value;                
            l.Size = new Size(130, 12);    
            x += 0;
            y += l.Height + 5;       
                 
            l.Location = new Point(x, y);
    
            grpBoxInstructions.Controls.Add(l);
        }
    }
