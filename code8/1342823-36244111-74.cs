    Player playerInstance;
    void Start()
    {
        //Must create instance once
        playerInstance = new Player();
        deserialize();
    }
    
    void deserialize()
    {
        string jsonString = "{\"playerId\":\"8484239823\",\"playerLoc\":\"Powai\",\"playerNick\":\"Random Nick\"}";
    
        //Overwrite the values in the existing class instance "playerInstance". Less memory Allocation
        JsonUtility.FromJsonOverwrite(jsonString, playerInstance);
        Debug.Log(playerInstance.playerLoc);
    }
