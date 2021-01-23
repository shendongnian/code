    new Button
    {
        Text = "Kick progress bar",
        Command = new Command(() =>
        {
            if (progressBar.AnimationIsRunning("SetProgress"))
            {
                progressBar.AbortAnimation("SetProgress");
            }
            else
            {
                progressBar.Animate("SetProgress",(arg) => { progressBar.Progress = arg; }, 8*60, 8*1000, Easing.Linear);
            }
        })
    }
