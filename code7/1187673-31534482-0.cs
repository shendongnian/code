	private void AudioSessionManager_OnSessionCreated(object sender, IAudioSessionControl newSession)
	{
		AudioSessionControl audioSession = new AudioSessionControl(newSession);
		// mute
		audioSession.SimpleAudioVolume.Mute = true;
	}
