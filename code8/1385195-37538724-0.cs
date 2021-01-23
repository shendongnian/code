    public sealed class AudioPlayer : IBackgroundTask
    {
    	public void Run(IBackgroundTaskInstance taskInstance)
    	{
    		BackgroundMediaPlayer.MessageReceivedFromForeground += BackgroundMediaPlayer_MessageReceivedFromForeground;
    		...
    		...
    	}
    
    	private async void BackgroundMediaPlayer_MessageReceivedFromForeground(object sender, MediaPlayerDataReceivedEventArgs e)
    	{
    		object value;
    		if (e.Data.TryGetValue("playnew", out value) && value != null)
    		{
    			// value will be whatever you pass from the foreground.
    			BackgroundMediaPlayer.Current.Pause();
    			BackgroundMediaPlayer.Current.Source = stream source;
    			BackgroundMediaPlayer.Current.Play();
    		}
    	}
    	
    	...
    }
