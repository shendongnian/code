    public class LinkableState : Entity
    {
        ...   
        public long? LinkableStatesId { get; set; }
        public long? LinkableStateTopCounterId { get; set; }
        [InverseProperty(@"LinkableStates")]
        [ForeignKey(@"LinkableStatesId")]
        public virtual ProcessInstance ProcessInstanceLinkableStates { get; set; }
        [InverseProperty(@"LinkableStateTopCounter")]
        [ForeignKey(@"LinkableStateTopCounterId")]
        public virtual ProcessInstance ProcessInstanceLinkableStateTopCounter { get; set; }
    }
    public class ProcessInstance : InstanceBase<Process>
    {
        ...
        [InverseProperty(@"ProcessInstanceLinkableStates")]
        public virtual ICollection<LinkableState> LinkableStates { get; set; } = new List<LinkableState>();
        [InverseProperty(@"ProcessInstanceLinkableStateTopCounter")]
        public virtual ICollection<LinkableState> LinkableStateTopCounter { get; set; } = new List<LinkableState>(); 
    }
