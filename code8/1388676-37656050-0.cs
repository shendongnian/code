    //pictures to labels
    public void AssignPicsToLabels()
    {
        var iconIndices = Enumerable.Range(0, icons.Count-1).ToList();
        Shuffle(iconIndices);
        int nIcon = 0;
        foreach (Control control in tableLayoutPanel1.Controls)
        {
            Label iconLabel = control as Label;
            if (iconLabel != null)
            {
                // TODO - check for array out of bounds
                iconLabel.Tag = iconIndices[nIcon++];
            }
        }
    }
