    class PlayerCharacter : ICombatant
    {
        // ... a lot of code ...
        public string GetCombatantName()
        {
            return String.Format("Character: {0}", this.CharacterName);
        }
    }
    class MonsterCharacter: ICombatant
    {
        // ... a lot of code ...
        public string GetCombatantName()
        {
            return String.Format("Monster: {0}", this.MonsterName);
        }
    }
