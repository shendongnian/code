    public class Transaction
    {
    	public int LocalId { get; set; }
    	public int MachineId { get; set; }
    	public virtual Machine Machine { get; set; }
    	public virtual TransactionMoney Money { get; set; }
    }
    
    public class Machine
    {
    	public int Id { get; set; }
    	public string Name { get; set; }
    	public virtual ICollection<Transaction> Transactions { get; set; }
    	public virtual ICollection<TransactionMoney> Money { get; set; }
    }
    
    public class TransactionMoney
    {
    	public int MachineId { get; set; }
    	public virtual Machine Machine { get; set; }
    	public int TransactionId { get; set; }
    	[ForeignKey("TransactionId,MachineId")]
    	public virtual Transaction Transaction { get; set; }
    }
