    public class Blog : IValidatableObject
        {
            public int Id { get; set; }
            [Required]
            public string Title { get; set; }
            public string BloggerName { get; set; }
            public DateTime DateCreated { get; set; }
            public virtual ICollection<Post> Posts { get; set; }
            public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
            {
                if (Title == BloggerName)
                {
                    yield return new ValidationResult
                     ("Blog Title cannot match Blogger Name", new[] { "Title", “BloggerName” });
                }
            }
        }
