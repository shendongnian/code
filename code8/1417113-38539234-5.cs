    private void SetupGradientShift()
    {
        GradientBrush BackBrush = this.Background as GradientBrush;
        if (BackBrush != null)
        {
            INameScopeDictionary nameScope = (INameScopeDictionary)NameScope.GetNameScope(this);
            foreach (GradientStop gradientStop in BackBrush.GradientStops.OrderBy(stop => stop.Offset))
            {
                DoubleAnimationUsingKeyFrames daukf =
                    new DoubleAnimationUsingKeyFrames
                    {
                        KeyFrames =
                            new DoubleKeyFrameCollection
                            {
                                new LinearDoubleKeyFrame(1.0, KeyTime.FromPercent(1.0))
                            },
                        Duration = TimeSpan.FromSeconds(3)
                    };
                this._sbGradientShifter.Children.Add(daukf);
                string name = nameScope.First(kvp => kvp.Value == gradientStop).Key;
                Storyboard.SetTargetName(daukf, name);
                Storyboard.SetTargetProperty(
                    daukf, new PropertyPath(GradientStop.OffsetProperty));
            }
            this._sbGradientShifter.Begin(this);
        }
    }
