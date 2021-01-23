    public void Die()
    {   
        if (Input.GetKeyUp ("r")) 
            {
                generateInstance.destroy();
                Application.LoadLevel (Application.loadedLevel);
            }
    }
