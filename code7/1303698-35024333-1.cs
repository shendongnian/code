    public void videoFinished(NSNotification notify){
    	if (notify.Name == AVPlayerItem.TimeJumpedNotification) {
    		Console.WriteLine ("{0} : {1}", _playerItem.Duration, _player.CurrentTime);
    		if (Math.Abs(_playerItem.Duration.Seconds - _player.CurrentTime.Seconds) < 0.001) {
    			Console.WriteLine ("Seek to end by user");
    		}
    	} else if (notify.Name == AVPlayerItem.DidPlayToEndTimeNotification) {
    		Console.WriteLine ("Normal finish");
    	} else {
    		// PlaybackStalledNotification, ItemFailedToPlayToEndTimeErrorKey, etc...
    		Console.WriteLine (notify.Name);
    	}
    }
