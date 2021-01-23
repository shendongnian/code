    public class MemberPaymentVM // for the table rows
    {
        public MemberPaymentVM(int categoryCount)
        {
            Amounts = new List<decimal>(new decimal[categoryCount]);
        }
        public string Name { get; set; }
        public List<decimal> Amounts { get; set; }
        public decimal Total { get; set; }
    }
    public class MonthPaymentsVM
    {
        [DisplayFormat(DataFormatString = "{0:MMMM yyyy}"]
        public DateTime Date { get; set; }
        public IEnumerable<string> Categories { get; set; }
        public List<MemberPaymentVM> Payments { get; set; }
    }
