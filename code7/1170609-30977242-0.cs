    [Flags]
    enum AnimalType
    {
      Dog = 1,
      Cat = 2,
      Bird = 4,
      Wolf = 8
    } 
    static class Program
    {
        static void Main(string[] args)
        {
            var test = AnimalType.Dog.AllContaining();
        }
        public static int[] AllContaining(this AnimalType thisAnimal)
        {
            List<int> retVal = new List<int>();
            var possibleEnums = Enum.GetValues(typeof(AnimalType)).Length;
            var maxValue = (int)Math.Pow(2, possibleEnums);
            for (int i = 0; i < maxValue; i++)
            {
                if (((AnimalType)i).HasFlag(thisAnimal))
                {
                    retVal.Add(i);
                }
            }
            return retVal.ToArray();
        }
    }
