    private void CreateLabelsForTesting(GroupBox grpBoxInstructions)
    {    
        // This will remember the last position between loops
        var lastPos = 0;
        
        foreach (KeyValuePair<string, string> labels in LabelTexts)
        {
            Label l = new Label();
            l.Name = labels.Key;
            l.Text = labels.Value;                
            l.Size = new Size(130, 12);                
            l.Location = new Point(0, lastPos);
            lastPos += 15; // Adds 15 to the previous value
            grpBoxInstructions.Controls.Add(l);
        }
    }
