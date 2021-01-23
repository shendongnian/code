    PictureBox img = new System.Windows.Forms.PictureBox();
    var result = GetImageAsync(ThumbnailUrl);
    result.ContinueWith(task =>
    {
        img.Image = task.Result;
    });
