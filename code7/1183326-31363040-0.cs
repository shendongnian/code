    public async void CycleThrough(string ImageDirectory, int FPS, int maxFrames, bool isLooping)
    {
        for (int i = frame; i < maxFrames + 1; i++)
        {
            ImageName = ImageDirectory + @"\" + i.ToString() + ".png";
            AnimationBox.Image = Image.FromFile(ImageName);
            AnimationBox.Refresh();
            await Task.Delay(TimeSpan.FromSeconds(1/FPS));
            if(isLooping && i == maxframes)
            {
                i = frame;
            }
        }
    }
