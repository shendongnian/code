    private void AddStyles(Stylesheet styleSheet)
        {
            var patternFill = new PatternFill
            {
                PatternType = PatternValues.Solid,
                ForegroundColor = new ForegroundColor { Rgb = "FFFF0000" },
                BackgroundColor = new BackgroundColor { Indexed = 64U }
            };
            var fill = new Fill { PatternFill = patternFill };
            styleSheet.Fills.AppendChild(fill);
         }
