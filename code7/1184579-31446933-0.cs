    public class PayStub
    {
    public int PayStubId { get; set; }
    public int Code { get; set; }
    public string Name { get; set; }
    public List<Payment> Payments{ get; set; }
    }
    public class Payment
