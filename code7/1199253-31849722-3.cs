	void Update()
    {
		_framesRendered++;
		
		if ((DateTime.Now - _lastTime).TotalSeconds >= 1)
		{
            // one second has elapsed 
			_fps = _framesRendered;						
			_framesRendered = 0;			
			_lastTime = DateTime.Now;
		}
		
		// draw FPS on screen here using current value of _fps			
	}
        
