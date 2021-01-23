    public class AgeClass
        {
            public string AgeG { get; set; }
            public int count { get; set; }
            public AgeClass()
            {
                AgeG = "";
                count = 0;
            }
            public AgeClass(string Age, int C)
            {
                AgeG = Age;
                count = C;
            }
        }
