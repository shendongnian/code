    // this is a class variable
    private bool isGameOver;
    // Assume this function will be called when game start
    public void GameStart()
    {
        isGameOver = false;
        // do other stuff;
    }
    // Assume this function will be called after game over
    public void GameOver()
    {
        isGameOver = true;
        // do other stuff;
    }
    // Assume this function will handle key down event
    public void KeyDownEventHandler(object sender, EventArgs e)
    {
        if (isGameOver) return;
        // do other stuff;
    }
