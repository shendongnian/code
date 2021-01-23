        private void WindowLoaded(object sender, EventArgs e)
        {
            // Fill the overline decoration with a solid color brush.
            TextDecorationCollection myCollection = new TextDecorationCollection();
            TextDecoration myStrikeThrough = new TextDecoration();
            myStrikeThrough.Location = TextDecorationLocation.Strikethrough;
            // Set the solid color brush.
            myStrikeThrough.Pen = new Pen(Brushes.Red, 2);
            myStrikeThrough.PenThicknessUnit = TextDecorationUnit.FontRecommended;
            // Set the underline decoration to the text block.
            myCollection.Add(myStrikeThrough);
            tb.TextDecorations = myCollection;
        }
