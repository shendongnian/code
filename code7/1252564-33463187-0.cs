    public void addVideo(Video video)
    {
        Console.WriteLine("Size 1 " + videos.Count);
        videos.Add(video);
        if (videosFiltered != videos)
            videosFiltered.Add(video);
        Console.WriteLine("Size 2 " + videos.Count);
    }
