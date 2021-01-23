    public static IEnumerable<VideoInfo> GetVideoInfos(YoutubeModel model)
    {
        int xx;
        IEnumerable<VideoInfo> videoInfos = DownloadUrlResolver.GetDownloadUrls(model.Link);
         
            int[] arr = new int[3] { 360, 720, 1080 };
            for (xx = 0; xx < 3; xx++)
            {
                try 
                {
                    VideoInfo video = videoInfos
                                       .First(info => info.VideoType == VideoType.Mp4 && info.Resolution == arr[xx]);
                }
                catch (Exception st)
                {
                }
            }
        return videoInfos;
    }
    //Returns VideoInfo object (Only for video model)
    public static VideoInfo GetVideoInfo(YoutubeVideoModel videoModel)
    {
        //Select the first .mp4 video with 360p resolution
        VideoInfo video = videoModel.VideoInfo.First();
        return video;
    }
