    IEnumerable<VideoInfo> videos = DownloadUrlResolver.GetDownloadUrls(txtUrl.Text);
    foreach (var vid in videos) {
        if (vid.Resolution > maxRez)
            maxRez = vid.Resolution;
    }
    cboRezolution.Text = maxRez.ToString();
    VideoInfo video = videos.First(p => p.VideoType == VideoType.Mp4 && p.Resolution == Convert.ToInt32(maxRez));
    lblStatus.Text = video.Title;
