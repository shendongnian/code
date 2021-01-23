    public class Box
        {
            public string Value { get; set; }
            public static List<string> AllowedValues { get; private set; }
    
            public Box()
            {
                AllowedValues.AddRange(new string[]{"10x10","20x20","22x15"});
                Value = AllowedValues.First();
            }
        }
