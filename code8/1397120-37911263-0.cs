    void GameOver()
    {
       Invoke("EnableNewGameButtonAfterDelay", 5f);
    }
    
    
    void EnableNewGameButtonAfterDelay()
    {
       _newGameButton.SetActive(true);
       // now this game object is active and user can click on it.
    }
