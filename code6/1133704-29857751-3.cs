    class CharacterManager
    {
        public enum CHAR_TYPE = { characterA, characterB, characterC }
        private Dictionary<CHAR_TYPE, bool> characterUnlockState;
    
        void Start()
        {
            // Seeding with some data for example purposes
            characterUnlockState = new Dictionary<CHAR_TYPE, bool>();
            characterUnlockState.Add(CHAR_TYPE.characterA, false);
            characterUnlockState.Add(CHAR_TYPE.characterB, false);
            characterUnlockState.Add(CHAR_TYPE.characterC, true);
        }
        public bool IsCharacterUnlocked(CHAR_TYPE character)
        {
            if (characterUnlockState.Contains(character)) return characterUnlockState[character];
        
            return false;
        }
        public void UnlockCharacter(CHAR_TYPE character)
        {
            if (characterUnlockState.Contains(character)) characterUnlockState[character] = true;
        }
    }
    class GenericCharacterController
    {
        public CHAR_TYPE character;
        public CharacterManager manager;
        public void UnlockButtonPressed()
        {
            manager.UnlockCharacter(character);
        }
        
    }
