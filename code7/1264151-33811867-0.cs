    interface IVersion_1
    {
        WeirdDad Weird { get; set; }
    }
    interface IVersion_2
    {
        WeirdChild Weird { get; set; }
    }
    class Version_1 : IVersion_1
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public WeirdDad Weird { get; set; }
        public MysteriousDad Mysterious { get; set; }
    }
    class Version_2 : Version_1, IVersion_2
    {
        public string IdentityCode { get; set; }
        WeirdChild IVersion_2.Weird { get; set; }
    } 
