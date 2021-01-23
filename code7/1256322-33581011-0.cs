    using System.Windows.Media;
    
    public void PlaySoundAsync(string filename)
    {
        // This plays the file asynchronously and returns immediately.
        MediaPlayer mp = new MediaPlayer();
        mp.MediaEnded += new EventHandler(Mp_MediaEnded);
        mp.Open(new Uri(filename));
        mp.Play();
    }
    
    private void Mp_MediaEnded(object sender, EventArgs e)
    {
        // Close the player once it finished playing. You could also set a flag here or raise another event.
        ((MediaPlayer)sender).Close();
    }
