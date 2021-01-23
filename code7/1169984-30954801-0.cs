    public class Amount
        {
            public Int64 Id { get; set; }
            public Int64 Amt1 { get; set; }
            public Int64 Amt2 { get; set; }
            public Amount(Int64 Id, Int64 Amt1, Int64 Amt2)
            {
                this.Id = Id;
                this.Amt1 = Amt1;
                this.Amt2 = Amt2;
            }
        }
        public class NewAmountDo
        {
            public Int64 newAmt { get; set; }
            public NewAmountDo(Int64 newAmt)
            {
                this.newAmt = newAmt;
            }
        }
