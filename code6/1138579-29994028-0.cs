    // This combines the fields from Member and RealEstate
    // for a row to be displayed in the data grid.
    public class MemberRealEstate
    {
        public int MemberID { get; set; }
        public string MemberName { get; set; }
        public int EstateID { get; set; }
        public string EstateType { get; set; }
        public double EstatePrice { get; set; }
        public string EstateArea { get; set; }
    } 
