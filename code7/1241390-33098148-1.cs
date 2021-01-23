    private void UpdateLabel(int index, PathInfo piToBeAdded)
    {
        plotCanvas.Children.Remove(names[index]);
        TextBlock text = new TextBlock();
        text.TextAlignment = TextAlignment.Left;
        text.FontSize = 12;
        text.Inlines.Add(new Run("(" + (GetPathsIndexFromId(piToBeAdded.ID) + 1) + ")ID:" + piToBeAdded.ID + " " + piToBeAdded.Name) { FontWeight = FontWeights.Bold });
        plotCanvas.Children.Add(text); // <---- moved this up
        Canvas.SetLeft(text, piToBeAdded.Center.X);
        Canvas.SetTop(text, piToBeAdded.Center.Y);
        names[index] = text;
    }
