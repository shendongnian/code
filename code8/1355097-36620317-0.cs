        public partial class Operation
        {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Operation()
        {
            this.ParameterSets = new HashSet<ParameterSet>();
        }
    
        public long ID { get; set; }
        public long OperationPLC_ID { get; set; }
        public string OperationIdentifier { get; set; }
        public System.DateTime ChangedOn { get; set; }
        public bool IsInUse { get; set; }
        public bool DoesTCApply { get; set; }
        public string OperationContent { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ParameterSet> ParameterSets { get; set; }
    }
