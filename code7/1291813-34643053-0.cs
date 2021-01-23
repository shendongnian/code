    void NewPlayerButtonClicked(string characterClass)
    {
        var player = new Player();
        if (characterClass == "Mage")
        {
            player.Role = new Mage();
        }
        // ...
    }
