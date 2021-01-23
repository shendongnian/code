    class DiceClass
    {
        private static string nL = Environment.NewLine;
        List<string> vals = new List<string>
        {
            nL + " l ",
            "l" + nL + nL + "  l",
            "l l" + nL + nL + "l l",
            "l l" + nL + nL + "l l",
            "l l" + nL + " l " + nL + "l l",
            "l l" + nL + "l l" + nL + "l l"
        };
        private const int BOX = 6;
        private int firstDie;
        private int secondDie;
        Random randomNums = new Random();
        public DiceClass()
        {
            firstDie = 0;
            secondDie = 0;
        }
        public void RollEm()
        {
            firstDie = randomNums.Next(1, 7);
            secondDie = randomNums.Next(1, 7);
        }
        public bool BoxCars()
        {
            return firstDie == 6 && secondDie == 6;
        }
        public bool SnakeEyes()
        {
            return firstDie == 1 && secondDie == 1;
        }
       
        public void GetRoll(ref string first, ref string second)
        {
            //str1 = GenerateString(numOne);
            //str2 = GenerateString(numTwo);
            first = vals[firstDie < 1 ? vals.Count - 1 : firstDie - 1];
            second = vals[secondDie < 1 ? vals.Count - 1 : secondDie - 1];
        }
    }
