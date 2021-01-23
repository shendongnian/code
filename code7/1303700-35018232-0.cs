    public class Applicant
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
    
        public virtual ICollection<MonthlyIncome> Incomes { get; set; }
    }
