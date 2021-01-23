    public Text[] highScores;
    
    public void hideHighScore()
    {
        for (int i = 0; i < 9; i++)
        {
            highScores[i].text = "";
            highScores[i].enabled = false;
        }
    }
    
    public void showHighScore()
    {
        SortedList<string, int> hScores = GetHighScores();
        for (int i = 0; i < 9; i++)
        {
            string tempName = "Highscore " + (i + 1);
            highScores[i].text = hScores[tempName].ToString();
            highScores[i].enabled = true;
        }
    }
    
    private SortedList<string, int> GetHighScores()
    {
        SortedList<string, int> tempList = new SortedList<string, int>();
    
        for (int i = 1; i < 10; i++)
        {
            string tempName = "Highscore " + i;
            tempList.Add(tempName, PlayerPrefs.GetInt(tempName));
        }
        return tempList;
    }
