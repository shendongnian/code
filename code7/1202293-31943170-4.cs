    public class WorkFlowState
    {
         public Guid Id { get; set; }
         [ForeignKey("PrevState")]
         public Guid? PrevStateId { get; set; }
         [ForeignKey("NextState")]
         public Guid? NextStateId { get; set; }
         public virtual WorkFlowState NextState { get; set; }
         public virtual WorkFlowState PrevState { get; set; }
    }
