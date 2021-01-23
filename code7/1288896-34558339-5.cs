    public class Faculty
    {
        private Faculty(FacultyEnum @enum)
        {
            Id = (int)@enum;
            Name = @enum.ToString();
            Description = @enum.GetEnumDescription();
        }
        protected Faculty() { } //For EF
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        public static implicit operator Faculty(FacultyEnum @enum) => new Faculty(@enum);
        public static implicit operator FacultyEnum(Faculty faculty) => (FacultyEnum)faculty.Id;
    }
