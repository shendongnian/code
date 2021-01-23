            private static void Main(string[] args)
            {
                var type = AnimalType.Wolf;
    
                foreach (var x in GetAllPossibleCombinationWith(type))
                {
                    Console.WriteLine(x);
                }
    
    
                Console.ReadLine();
            }
    
    
            public static IEnumerable<AnimalType> GetAllPossibleCombinationWith(AnimalType type) // Bird
            {
                var maxValue = Enum.GetValues(typeof(AnimalType)).Cast<int>().Max();
                var combinationValue =2* maxValue - 1;
                for (int i = 0; i < combinationValue; i++)
                {
                    var val = (AnimalType) i;
                    if ((val & type) == type) yield return val;
                }
            }
    
            [Flags]
            public enum AnimalType
            {
                Dog = 1,
                Cat = 2,
                Bird = 4,
                Wolf = 8,
                Fish = 16
            }
