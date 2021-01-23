    Character char = new Character();
    char.Name = "Apple";
    char.Level = 1;
    char.Health = 150;
    char.Attributes = new int[] { 10, 10, 10 };
    
    PlayerPrefs.SetString( "PlayerCharacter", JsonConvert.SerializeObject(char) );
