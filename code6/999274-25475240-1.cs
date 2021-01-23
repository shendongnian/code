    //create the video
    Microsoft.DirectX.AudioVideoPlayback.Video video = new Microsoft.DirectX.AudioVideoPlayback.Video(fileName);
    //set the System.Windows.Forms.Control to play it in (e.g a panel)
    video.Owner = panel1;
    //Play the video (put this in a buttons click event)
    video.Play();
    //Pause the video (put this in a buttons click event)
    video.Pause();
    //Stop the video (put this in a buttons click event)
    video.Stop();
