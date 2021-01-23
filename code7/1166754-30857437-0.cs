	public void LoadSong()
	{
		StartCoroutine(LoadSongCoroutine());	
	}
	IEnumerator LoadSongCoroutine()
	{
		string url = string.Format("file://{0}", path); 
		WWW www = new WWW(url);
		yield return www;
		song.clip = www.GetAudioClip(false, false);
        songName =  song.clip.name;
        length = song.clip.length;
	}
