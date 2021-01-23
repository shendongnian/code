    public class Bill
    {
        public float Total
        {
            get
            {
                return BillLineList.Sum(x => x.FinalBillLinePrice);
            }
          
        }
        public List<BillLine> BillLineList { get; set; }
    }
