    private void isGameOver()
    {
        bool gameOver = false;
        
        for(int i = 0; i < studentScripts.Count; i++)
        {
            if (studentScripts[i].m == 5) 
            {
                gameOver = true;
            }
            else 
            {
                gameOver = false;
                break;
            }
        }
        
        if(gameOver) StartCoroutine(ChangeScene());
    }
    void Update()
    {
        isGameOver();
    }
