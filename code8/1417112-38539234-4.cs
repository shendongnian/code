    private void SetupGradientShift()
    {
        string[] names = { "stop1", "stop2" };
        foreach (string name in names)
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
            Storyboard.SetTargetName(daukf, name);
            Storyboard.SetTargetProperty(
                daukf, new PropertyPath(GradientStop.OffsetProperty));
        }
        this._sbGradientShifter.Begin(this);
    }
