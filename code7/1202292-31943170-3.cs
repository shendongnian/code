    public class WorkFlowState
    {
         public Guid Id { get; set; }
         public virtual WorkFlowState NextState { get; set; }
         [Required]
         public virtual WorkFlowState PrevState { get; set; }
    }
