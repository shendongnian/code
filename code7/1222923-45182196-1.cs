    public bool started = false;
		
	void Update ()
	{
		if (started == false) {
			started = true;
			StartCoroutine (playMovie ());
		}
	}
    public IEnumerator PlayMovie ()
    {      
       yield Handheld.PlayFullScreenMovie ("splash.mp4", 
       Color.black,FullScreenMovieControlMode.Hidden, 
       FullScreenMovieScalingMode.AspectFit);
        
       Application.LoadLevel ("home");
    }
