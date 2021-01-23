        private Style GetViewColumnStyle()
        {
            // The TextBlock
            FrameworkElementFactory textBlockFactory = new FrameworkElementFactory(typeof(TextBlock));
            // DataBinding for TextBlock.Text
            Binding textBinding = new Binding("YourTextBindingPath");
            textBlockFactory.SetValue(TextBlock.TextProperty, textBinding);
            //Other TextBlock attributes
            textBlockFactory.SetValue(TextBlock.TextAlignmentProperty, TextAlignment.Center);
            textBlockFactory.SetValue(TextBlock.BackgroundProperty, Brushes.LightGray);
            textBlockFactory.SetValue(TextBlock.ForegroundProperty, Brushes.Black);
            textBlockFactory.SetValue(TextBlock.MarginProperty, new Thickness(2, 2, 2, 2));
            // The Border around your TextBlock
            FrameworkElementFactory borderFactory = new FrameworkElementFactory(typeof(Border));
            borderFactory.SetValue(Border.BorderBrushProperty, Brushes.Black);
            borderFactory.SetValue(Border.BorderThicknessProperty, new Thickness(1, 1, 1, 1));
            // Add The TextBlock to the Border as a child element
            borderFactory.AppendChild(textBlockFactory);
            // The Template for each DataGridCell = your Border that contains your TextBlock
            ControlTemplate cellTemplate = new ControlTemplate();
            cellTemplate.VisualTree = borderFactory;
            // Setting Style.Template
            Style oStyle = new Style(typeof(DataGridCell));
            Setter templateSetter = new Setter(DataGridCell.TemplateProperty, cellTemplate);
            oStyle.Setters.Add(templateSetter);
            return oStyle;
        }
