    class RollDice
    {
        Random randomNums = new Random();
    
        public int RollDice1()
        {
            return randomNums.Next(1, 7);
        }
    
        public int RollDice2()
        {
            return randomNums.Next(1, 7);
        }
    }
