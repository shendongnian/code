        Style PrepareAnimationStyle()
        {
            Trigger animTrigger = new Trigger();
            animTrigger.Property = FrameworkElement.IsMouseOverProperty;
            animTrigger.Value = true;
            ColorAnimation strokeToGreen = new ColorAnimation((Color)ColorConverter.ConvertFromString("#FF66CC00"), TimeSpan.FromSeconds(0));
            ColorAnimation strokeToSilver = new ColorAnimation(Colors.Silver, TimeSpan.FromSeconds(1));
            ColorAnimation fillToGreen = new ColorAnimation((Color)ColorConverter.ConvertFromString("#FF66CC00"), TimeSpan.FromSeconds(0));
            ColorAnimation fillToTransparent = new ColorAnimation(Colors.Transparent, TimeSpan.FromSeconds(1));
            Storyboard sbEnter = new Storyboard();
            Storyboard.SetTargetProperty(strokeToGreen, new PropertyPath("Stroke.Color"));
            Storyboard.SetTargetProperty(fillToGreen, new PropertyPath("Fill.Color"));
            sbEnter.Children.Add(strokeToGreen);
            sbEnter.Children.Add(fillToGreen);
            Storyboard sbExit = new Storyboard();
            Storyboard.SetTargetProperty(strokeToSilver, new PropertyPath("Stroke.Color"));
            Storyboard.SetTargetProperty(fillToTransparent, new PropertyPath("Fill.Color"));
            sbExit.Children.Add(strokeToSilver);
            sbExit.Children.Add(fillToTransparent);
            animTrigger.EnterActions.Add(new BeginStoryboard() { Storyboard = sbEnter });
            animTrigger.ExitActions.Add(new BeginStoryboard() { Storyboard = sbExit });
            Style cellStyle = new Style();
            cellStyle.Triggers.Add(animTrigger);
            return cellStyle;
        }
