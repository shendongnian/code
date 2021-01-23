    private void VideoEnd(MediaElement me, string vidName)
    {
        me.MediaEnded += (a, b) =>
       {
           Random rand = new Random(DateTime.Now.ToString().GetHashCode());
           randIndex = rand.Next(0, videoPlayListFill.Count);
           mediaPlayerGrid.Children.Remove(me);
           createMediaElement(videoPlayListFill[randIndex].Filename);
       };
    }
