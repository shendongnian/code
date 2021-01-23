       public void CreateText()
        {
            FontStyle fontStyle = FontStyles.Normal;
            FontWeight fontWeight = FontWeights.Medium;
            //if (FontWeight == FontWeights.Bold) fontWeight = FontWeights.Bold;
            // if (FontStyle == FontStyles.Italic) fontStyle = FontStyles.Italic;
            // Create the formatted text based on the properties set.
            FormattedText formattedText = new FormattedText(
                Text,
                CultureInfo.GetCultureInfo("en-us"),
                FlowDirection.LeftToRight,
                new Typeface(FontFamily, FontStyle, FontWeight, FontStretches.Normal, new FontFamily("Arial")),
                FontSize,
                Brushes.Black // This brush does not matter since we use the geometry of the text. 
                );
            // Build the geometry object that represents the text.
            _textGeometry = formattedText.BuildGeometry(new Point(4, 4));
            //set the size of the custome control based on the size of the text
            this.MaxWidth = formattedText.Width + 100;
            this.MaxHeight = formattedText.Height + 10;
        }
