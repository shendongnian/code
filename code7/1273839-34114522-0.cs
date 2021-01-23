    void Update () {
    
        if(Input.GetKeyDown(KeyCode.Return) && (CurrentLevel == 0)){
            CurrentLevel = 1;
            Application.LoadLevel (CurrentLevel);
        }
    
        if (CharacterMovement.Score == 10) {
            CurrentLevel = 2;
            CharacterMovement.Score = 11;
            Application.LoadLevel (CurrentLevel);
    
        }
    
        if ((CurrentLevel != 5) && (CharacterMovement.Lives == 0)) { // Change this
            isLost = true;
            Debug.Log ("is now true");
            CurrentLevel = 5;
            Debug.Log ("current level is set to 5");
            Application.LoadLevel (CurrentLevel);
        }
    
        if (CurrentLevel == 5) {
            Debug.Log ("this is level 5");
            if (Input.GetKeyDown(KeyCode.Tab)) {
                Debug.Log ("tab is pressed");
    
            }
        }
    }
