    public class RegDataTableVM
    {
      ....
      public StudentReceipt Receipt { get; set; }
      public string NextDueAmount
      {
        get { return Receipt == null ? "FULL PAID" ? Receipt.Total.ToString() }
      }
      public string NextDueDate 
      {
        get { return Receipt == null ? "FULL PAID" ? Receipt.DueDate.ToString("dd/MM/yyyy") }
      }
