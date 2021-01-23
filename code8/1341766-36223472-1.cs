    public class Balance
    {
       public int BalanceId { get; set; }
       public IEnumerable<Expense> Despesas { get; set; }
       public IEnumerable<Earning> Rendimentos { get; set; }
       public string ApplicationUserId { get; set; }
    }
