    private void Update()
    {
        //  Is it time to load the next scene?
        if(Time.time >= _loadSceneTime)
        {
            //  Load Scene
        }
        else
        {
            //  NOTE: GET PLAYERS POSITION...THIS ASSUMES THIS 
            //  SCRIPT IS ON THE GAME OBJECT REPRESENTING THE PLAYER
            Vector3 playerPosition = this.transform.position;
            
            //  Has the player moved?
            if(playerPosition != _lastPlayerPosition)
            {
                //  If the player has moved we will attempt to load 
                //  the scene in x-seconds
                _loadSceneTime = Time.time + _playerIdleDelay;
            }
            
            _lastPlayerPosition = playerPosition;
        }
    }
