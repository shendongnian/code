    public class Request
    {
        public virtual int BudgetHolderEmployeeId { get; set; }
        [ForeignKey("BudgetHolderEmployeeId")]
        public virtual Employee BudgetHolder { get; set; }
        public virtual int FinancialControllerEmployeeId { get; set; }
        [ForeignKey("FinancialControllerEmployeeId")]
        public virtual Employee FinancialController { get; set; }
    }
