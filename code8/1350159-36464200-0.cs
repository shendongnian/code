    public class class1
    {
        public static string value { get; set; } // use the proper type here if it's not a string
        public static void emp(string name)
        {
            .....
            this.value = (value that is returned)
        }
    }
    public class class2
    {
        public static void studen(string division)
        {
            class1.emp("Hello");
            string class2Var = class1.value; // class2Var will now be "Hello"
        }
    }
