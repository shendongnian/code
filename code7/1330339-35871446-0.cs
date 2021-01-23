    // This will remember the last position between loops
    int lastPos = 0;
    private void CreateLabelsForTesting(GroupBox grpBoxInstructions)
    {            
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
