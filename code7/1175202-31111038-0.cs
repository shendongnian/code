        DateTime Date { get; }
        int Number { get; }
        int SchoolClassCodeId { get; }
        int SchoolYearId { get; }
        int TestTypeId { get; }
        int? TestId { get; }
    }
    public class EditTestDTO : ITestDTO
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        public int SchoolClassCodeId { get; set; }
        [Required]
        public int SchoolYearId { get; set; }
        [Required]
        public int TestTypeId { get; set; }
        [Required]
        public int TestId { get; set; }
        int? ITestDTO.TestId { get { return TestId; } }
    }
    public class CreateTestDTO : ITestDTO
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        public int SchoolClassCodeId { get; set; }
        [Required]
        public int SchoolYearId { get; set; }
        [Required]
        public int TestTypeId { get; set; }
        int? ITestDTO.TestId { get { return null; } }
    }
