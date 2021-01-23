    public class Job
    {
        public int Id { get; set; }
        public float Price { get; set; }
        public int JobSubCategoryId { get; set; }
        public string JobDescription { get; set; }
        public int SpecialRequirementId { get; set; }
        public virtual List<Machine> Machines { get; set; }
    }
