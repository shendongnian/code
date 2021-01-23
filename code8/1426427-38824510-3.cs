    [System.Serializable]
    public class CharacterManager
    {
        public CharactersTypes charactersTypes = CharactersTypes.NONE;
        public Characters[] characters = new Characters[5];
        Sprite[] sprites = new Sprite[5];
    
        public CharacterManager()
        {
            charactersTypes = CharactersTypes.NONE;
            for (int i = 0; i < characters.Length; i++)
            {
                characters[i] = Characters.NONE;
            }
        }
    
        //Save Character
        public void saveCharacter()
        {
            string charJsonInfo = JsonUtility.ToJson(this);
            if (string.IsNullOrEmpty(charJsonInfo))
                return;
    
            PlayerPrefs.SetString("SaveCharacter", charJsonInfo);
            PlayerPrefs.Save();
        }
    
        //Load Character
        public static CharacterManager loadCharacter()
        {
            string charJsonInfo = PlayerPrefs.GetString("SaveCharacter");
            if (string.IsNullOrEmpty(charJsonInfo))
                return null;
    
            CharacterManager characterManager = JsonUtility.FromJson<CharacterManager>(charJsonInfo);
            Debug.Log("Json: " + charJsonInfo);
            return characterManager;
        }
    
        public Sprite[] getSavedSprites()
        {
            for (int i = 0; i < characters.Length; i++)
            {
                if (characters[i] != Characters.NONE)
                {
                    sprites[i] = Resources.Load("Characters/" + characters[i].ToString(), typeof(Sprite)) as Sprite;
                }
            }
            return sprites;
        }
    }
    
    //5 Character Types[Colors]
    public enum CharactersTypes
    {
        NONE, Green, Red, Purple, Orange, Blue
    }
    
    //25 Characters[Names]
    public enum Characters
    {
        NONE,
        RedMario,
        RedLuigi,
        RedPrincessPeach,
        RedYoshi,
        RedToad,
    
        GreenMario,
        GreenLuigi,
        GreenPrincessPeach,
        GreenYoshi,
        GreenToad,
    
        ////Add Orange ,Purple Blue and Orange Sprite enums below
    }
