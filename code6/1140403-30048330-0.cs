    class Program
    {
    private Model1 model = new Model1();
    static void Main(string[] args)
    {
        Program p = new Program();
        p.Run();
        var what = System.Console.ReadLine();
    }
    public void Run()
    {
        var voiding = this.model.Transactions
            .Where(t => t.IsVoid)
            .ToList();
        System.Console.WriteLine("Voiding transactions: ");
        this.PrintTransactions(voiding);
        var voided = this.model.Transactions
            .Where(t => t.IsVoid)
            .Join(this.model.Transactions.AsEnumerable(),
                t1 => t1.ImpactId,
                t2 => t2.Id,
                (t1, t2) => t2)
            .ToList();
        System.Console.WriteLine("Voided transactions: ");
        this.PrintTransactions(voided);
        var notVoided = this.model.Transactions
            .Except(this.model.Transactions
                .Where(t => t.IsVoid)
                .Join(this.model.Transactions.AsEnumerable(),
                    t1 => t1.ImpactId,
                    t2 => t2.Id,
                    (t1, t2) => t2))
            .Where(t => !t.IsVoid)
            .ToList();
        System.Console.WriteLine("The rest: ");
        this.PrintTransactions(notVoided);
    }
    private void PrintTransactions(ICollection<Transaction> transaction)
    {
        transaction.ToList()
            .ForEach(t =>
            {
                System.Console.WriteLine(string.Format("{0}, {1}, {2}, {3}", t.Id, t.Amount, t.IsVoid, t.ImpactId));
            });
    }
    }
