    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Seller Seller { get; set; }
    }
    public class Seller : Person
    {
        public decimal Comissao { get; set; }
        public Person Person { get; set; }
    }
