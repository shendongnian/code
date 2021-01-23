    public class ent_Message<ent_MessagePhoto>
        {
            public decimal messID { get; set; }
            public Nullable<decimal> userNumber { get; set; }
            public Nullable<decimal> messageTo { get; set; }
            public Nullable<System.DateTime> mDate { get; set; }
            public string ip { get; set; }
            public string Message1 { get; set; }
            public Nullable<bool> isRead { get; set; }
            public Nullable<decimal> parentID { get; set; }
            public string Name { get; set; }
            public IList<ent_MessagePhoto> photo { get; set; }
        }​
