    public class MyModel
    {
        public int Prop1 { get; set; }
        public bool Flag { get; set; }
        public object Prop2
        {
            get
            {
                if (Flag)
                {
                    return Instance1.TypeThatIsDifferentInDifferentInstances;
                }
                else
                {
                    return Instance2.TypeThatIsDifferentInDifferentInstances;
                }
            }
        }
    }
    public static class Instance1
    {
        public static int TypeThatIsDifferentInDifferentInstances = 1;
    }
    public static class Instance2
    {
        public static string TypeThatIsDifferentInDifferentInstances = "testString";
    }
