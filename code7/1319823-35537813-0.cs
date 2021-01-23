    public class Asset
    {
        public string name;
        public decimal Liability { get { return 0; } }
    }
    
    public class House : Asset
    {
        public decimal Mortgage;
        public decimal Liability { get { return Mortgage; } }
    }
    
    House mansion = new House { name = "SomeName", Mortgage = 100000 };
    Asset a = mansion;
    Console.WriteLine(mansion.Liability);      // 100000
    Console.WriteLine(a.Liability); //0 OK
