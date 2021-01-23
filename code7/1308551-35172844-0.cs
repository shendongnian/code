    void Main()
    {
        var transactions = ReadTransactionsInOldFormat(@"d:\temp\input.txt");
        WriteTransactionsInNewFormat(transactions, @"d:\temp\output.txt");
    }
    
    public static void WriteTransactionsInNewFormat(IEnumerable<Transaction> transactions, string filename)
    {
        using (var file = File.CreateText(filename))
            foreach (var transaction in transactions)
                file.WriteLine($"Set account {transaction.Name} {transaction.ComputerName} from {transaction.IpAddress} {transaction.Time} {transaction.Profit} to acc0001");
    }
    
    public static IEnumerable<Transaction> ReadTransactionsInOldFormat(string filename)
    {
        using (var file = File.OpenText(filename))
        using (var reader = new CsvReader(file))
        {
            reader.Configuration.HasHeaderRecord = true;
            reader.Configuration.Delimiter = "\t";
            reader.Configuration.RegisterClassMap<TransactionMap>();
    
            while (reader.Read())
                yield return reader.GetRecord<Transaction>();
        }
    }
    
    public class TransactionMap : CsvClassMap<Transaction>
    {
        public TransactionMap()
        {
            Map(m => m.Name).Index(0);
            Map(m => m.ComputerNameAndIpAddress).Index(1);
            Map(m => m.Time).Index(2);
            Map(m => m.Profit).Index(3);
        }
    }
    
    public class Transaction
    {
        public string Name { get; set; }
    
    
        public string ComputerNameAndIpAddress
        {
            get
            {
                return $"{ComputerName}/{IpAddress}";
            }
            set
            {
                var parts = value.Split('/');
                ComputerName = parts[0];
                IpAddress = parts[1];
            }
        }
    
        public string ComputerName { get; set; }
        public string IpAddress { get; set; }
        public int Time { get; set; }
        public int Profit { get; set; }
    }
