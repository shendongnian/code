    public async void CycleThrough(string ImageDirectory, int FPS, int maxFrames, bool isLooping)
    {
        for (int i = frame; i < maxFrames + 1; i++) // frame and maxFrames must not change. counter is i
        {
            ImageName = ImageDirectory + @"\" + i.ToString() + ".png"; // Get the i-th png using counter.
            AnimationBox.Image = Image.FromFile(ImageName);
            AnimationBox.Refresh();
            await Task.Delay(TimeSpan.FromSeconds(1/FPS)); // delay in seconds.
            if(isLooping && i == maxframes) // if must Loop and counter is in last iteration then start over
            {
                i = frame - 1; // set the counter to the first frame
            }
        }
    }
