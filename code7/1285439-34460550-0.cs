    void Update ()
    {
        string scoreText = score.ToString ();
        for (int i = 0; i < scoreText.Length; i++)
        {
            ((GameObject)Instantiate(Resources.Load(scoreText[i].ToString())).layer = 8;
        }
    }
