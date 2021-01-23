        private void InitTable()
        {
            int numOfCols = 14;
            UniformGrid grid = new UniformGrid();
            grid.Columns = numOfCols;
            grid.Children.Add(new TextBlock() { Text = "August", FontWeight = FontWeights.Bold });
            for (int n = 1; n < numOfCols; n++)
                grid.Children.Add(new TextBlock() { Text = (10 + n).ToString(), FontWeight = FontWeights.Bold });
            string[] rowHeaders = new string[] { "river", "explosion", "flu", "airport", "chills", "morning", "tech", "truck", "cold" };
            Style cellStyle = PrepareAnimationStyle();
            foreach (string label in rowHeaders)
            {
                grid.Children.Add(new TextBlock() { Text = label, FontWeight = FontWeights.Bold });
                for (int n = 1; n < numOfCols; n++)
                    grid.Children.Add(new Border()
                    {
                        BorderBrush = new SolidColorBrush(Colors.Silver),
                        Background = Brushes.Transparent,
                        BorderThickness = new Thickness(3),
                        Style = cellStyle
                    });
            }
            this.Content = grid;
        }
        Style PrepareAnimationStyle()
        {
            Trigger animTrigger = new Trigger();
            animTrigger.Property = ContentElement.IsMouseOverProperty;
            animTrigger.Value = true;
            ColorAnimation toGreen = new ColorAnimation((Color)ColorConverter.ConvertFromString("#FF66CC00"), TimeSpan.FromSeconds(0));
            toGreen.FillBehavior = FillBehavior.HoldEnd;
            ColorAnimation toSilver = new ColorAnimation(Colors.Silver, TimeSpan.FromSeconds(1));
            Storyboard sbEnter = new Storyboard();
            Storyboard.SetTargetProperty(toGreen, new PropertyPath("BorderBrush.Color"));
            sbEnter.Children.Add(toGreen);
            Storyboard sbExit = new Storyboard();
            Storyboard.SetTargetProperty(toSilver, new PropertyPath("BorderBrush.Color"));
            sbExit.Children.Add(toSilver);
            animTrigger.EnterActions.Add(new BeginStoryboard() { Storyboard = sbEnter });
            animTrigger.ExitActions.Add(new BeginStoryboard() { Storyboard = sbExit });
            Style cellStyle = new Style();
            cellStyle.Triggers.Add(animTrigger);
            return cellStyle;
        }
