    public class Character
    {
        private int totalPointsMax = 60;
        private int maxPoints = 18;
        private int minPoints = 7;
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }
        public Character()
        {
            // create new Character defaults...
            Strength = 10;
            Dexterity = 10;
            Constitution = 10;
            Intelligence = 10;
            Wisdom = 10;
            Charisma = 10;
        }
        private int GetTotalCharacterPoints()
        {
            return Strength + Dexterity + Constitution + Intelligence + Wisdom + Charisma;
        }
        //example of method to increase Strength
        public void IncreaseStrength()
        {
            int availablePoints = totalPointsMax - GetTotalCharacterPoints();
            if (availablePoints > 0 && Strength < maxPoints)
                Strength++;
        }
        //example of method to decrease Strength
        public void DecreaseStrength()
        {
            if (Strength >= minPoints)
                Strength--;
        }
        //missing the other increase/decrease methods for the rest of features...
    }
