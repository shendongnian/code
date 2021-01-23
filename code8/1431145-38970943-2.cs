    struct ContractData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public static ContractData Create(int id, string name, decimal value = 0)
        {
            return new ContractData() {Id = id, Name = name, Amount = value};
        }
    }
