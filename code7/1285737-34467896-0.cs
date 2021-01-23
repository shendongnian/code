    class Ans34467714
    {
        List<double> correctOnes = new List<double>() { 22.7, 22.6, 44.5, 44.5, 44.5};
        List<rotation> cubeRotation = new List<rotation>() { new rotation() { eulerAngles = 22.3 }, new rotation() { eulerAngles = 22.6 }, new rotation() { eulerAngles = 44.5 }, new rotation() { eulerAngles = 44.5 }, new rotation() { eulerAngles = 44.5 } };
        public Ans34467714()
        {
        }
        internal bool Execute(string[] args)
        {
            bool retValue = false;
            if (Deneme())
            {
                Console.WriteLine("Pass");
            }
            else
            {
                Console.WriteLine("Fail");
            }
            return retValue;
        }
        internal bool Deneme()
        {
            return correctOnes.Where((var, index) => cubeRotation[index].eulerAngles == var).Count() == correctOnes.Count;
        }
    }
    class rotation
    {
        public double eulerAngles {get; set;}
        public rotation()
        {
        }
    }
