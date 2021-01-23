    class MyClass
    {
        public decimal Id { get; set; }
        public decimal OtherNumber { get; set; }
        public override string ToString()
        {
            return string.Format("{0:000}/{1:0000}/{2:000}", this.Id, this.OtherNumber,  999.0m - this.Id );
        }
        static void Main(string[] args)
        {
            Console.WriteLine(new MyClass { Id = 123.0m, OtherNumber = 1234.0m }); // 123/1234/876
            Console.WriteLine(new MyClass { Id = 12.3m, OtherNumber = 123.4m }); // 012/1234/987
        }
    }
