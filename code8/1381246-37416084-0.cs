    public class BasicSubstanceViewModel 
    {
        public int NodeID { get; set; }
        public string CASNumber { get; set; }
        public string EINECSCode { get; set; }
        public string EUIndex { get; set; }
        public string Duty { get; set; }
        public string Prohibited { get; set; }
        public string Unwanted { get; set; }
        public string IsReach { get; set; }
        public string SubstanceName { get; set; }
        public List<GroupName> GroupName { get; set; }
        public decimal ?Portion { get; set; }
    }
    
    public class GroupName
    {
        public string Name { get; set; }
    }
