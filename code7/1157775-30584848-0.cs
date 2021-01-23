    class BaseClass
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual void TypeTest()
        {
            Console.WriteLine(FirstName != null ? "FirstName is NOT NULL!" : "FirstName IS NULL!");
            Console.WriteLine(LastName != null ? "LastName is NOT NULL!" : "LastName IS NULL!");
        }
    }
    class TypeOneAditionalInformation : BaseClass
    {
        public string X1 { get; set; }
        public string X2 { get; set; }
        public override void TypeTest()
        {
            base.TypeTest();
            Console.WriteLine(X1 != null ? "X1 is NOT NULL!" : "X1 IS NULL!");
            Console.WriteLine(X2 != null ? "X2 is NOT NULL!" : "X2 IS NULL!");
        }
    }
    class TypeTwoAditionalInformation : BaseClass
    {
        public string X3 { get; set; }
        public string X4 { get; set; }
        public override void TypeTest()
        {
            base.TypeTest();
            Console.WriteLine(X3 != null ? "X3 is NOT NULL!" : "X3 IS NULL!");
            Console.WriteLine(X4 != null ? "X4 is NOT NULL!" : "X4 IS NULL!");
        }
    }
