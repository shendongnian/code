    public class ClientPaymentInfo
    {
      public string ClientName { set;get;}
      public List<PaymentInfoVm> Payments { set;get;}
      public ClientPaymentInfo()
      {
        Payments = new List<PaymentInfoVm>();
      }
    }
    public class PaymentInfoVm
    {
      public int Id { set;get;}
      public string PaymentNumber { set;get;}
      public decimal Amount { set;get;}
    }
