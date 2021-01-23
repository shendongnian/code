    	private void BeginDelay()
        {
            this._animation = new DoubleAnimationUsingKeyFrames() { FillBehavior = FillBehavior.Stop };
            this._animation.KeyFrames.Add(new EasingDoubleKeyFrame(0, KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(0)), new CubicEase() { EasingMode = EasingMode.EaseIn }));
            this._animation.KeyFrames.Add(new EasingDoubleKeyFrame(1, KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(this.DelayMilliseconds)), new CubicEase() { EasingMode = EasingMode.EaseIn }));
            this._animation.Completed += (o, e) =>
            {
                this.DelayElapsed = 0d;
                this.Command.Execute(this.CommandParameter);	// Replace with whatever action you want to perform
            };
            this.BeginAnimation(DelayElapsedProperty, this._animation);
        }
        private void CancelDelay()
        {
            // Cancel animation
            this.BeginAnimation(DelayElapsedProperty, null);
        }
