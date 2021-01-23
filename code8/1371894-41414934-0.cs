    string path = "Video path";
    NReco.VideoInfo.FFProbe ffProbe = new NReco.VideoInfo.FFProbe();
    MediaInfo videoInfo = ffProbe.GetMediaInfo(path ); 
    
    TimeSpan videoDuration = videoInfo.Duration;
    if (videoInfo.Streams[index].CodecType.ToLower() == "video")
    {
     int iWidth = videoInfo.Streams[index].Width;
     int iHeight = videoInfo.Streams[index].Height;
     string sVideoFrameRate = videoInfo.Streams[index].FrameRate.ToString();
     string sVideoCodecName = videoInfo.Streams[index].VideoCodecName;
      //...
    }
    else if(videoInfo.Streams[index].CodecType.ToLower() == "audio")
    {
       string sAudioCodecName = videoInfo.Streams[index].CodecName;
      //...
    }
