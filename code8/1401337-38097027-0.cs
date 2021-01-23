    public class Machine
    {
        [Key]
        public long ID { get; set; }
        ...
        public virtual MachineTypeApprovalHist MachineTypeApproval { get; set; }
        //new property
        public virtual MachineTypeApprovalHist TypeApproval {get; set;} 
    }
