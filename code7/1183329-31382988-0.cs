    private async void CycleThrough(string ImageDirectory, int FPMS, int maxFrames, bool isLooping)
        {
            this.speed = FPMS;
            for (int i = frame; i < maxFrames + 1; i++)
            {
                ImageName = ImageDirectory + @"\" + i.ToString() + ".png";
                Console.WriteLine(frame.ToString());
                AnimationBox.Refresh();
                AnimationBox.Image = Image.FromFile(ImageName);
                await Task.Delay(FPMS);
                if (isLooping)
                {
                    if (i >= maxFrames) i = 1;
                }
            }
        }
