            // Your new paragraph with the hyperlink
            Paragraph hyperlinkParagraph = new Paragraph();
            // Run for the hyperlink
            Run hyperlinkRun = new Run();
            // Styling for the hyperlink
            RunProperties runPropertiesHyperLink = new RunProperties(
                new RunStyle { Val = "Hyperlink", },
                new Underline { Val = UnderlineValues.Single },
                new Color { ThemeColor = ThemeColorValues.Hyperlink });
            // Actual hyperlink
            Hyperlink xmlHyperLink = new Hyperlink()
            {
                Anchor = "https://stackoverflow.com",
                DocLocation = "https://stackoverflow.com"
            };
            // Text that you see to click on
            Text hyperLinkText = new Text("Click for going to StackOverflow!");
            // Apply the styling in this order to the run
            hyperlinkRun.Append(runPropertiesHyperLink);
            hyperlinkRun.Append(hyperLinkText);
            // Now add the run to the hyperlink
            xmlHyperLink.Append(hyperlinkRun);
            // Add the hyperlink to the paragraph
            hyperlinkParagraph.Append(xmlHyperLink);
            // Add paragraph to the body
            _mainBody.Append(hyperlinkParagraph );
