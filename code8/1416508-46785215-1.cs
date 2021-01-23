    public class Question
    {
        public Guid Id { get; private set; }
        public IReadOnlyList<Variant> Variants { get; private set; }
        public Guid CorrectVariantId { get; private set; }
        public Guid? AnsweredVariantId { get; private set; }    
        public bool IsAnswerCorrect => CorrectVariantId == AnsweredVariantId;
        public bool IsAnswered => AnsweredVariantId != null;
    }
    public class Variant
    {
        public Guid Id { get; private set; }
        public Guid QuestionId { get; private set; }
        public string HiddenUserLogin { get; private set; }
        public User HiddenUser { get; private set; }
    }
    // mapping
	mb.Entity<Question>()
		.HasMany(q => q.Variants)
		.WithOne()
		.HasForeignKey(nameof(Variant.QuestionId))
		.IsRequired()
		.OnDelete(DeleteBehavior.Cascade);
	mb.Entity<Question>()
		.HasOne(typeof(Variant))
		.WithOne()
		.HasForeignKey<Question>(nameof(Question.AnsweredVariantId))
		.IsRequired(false) 
		.OnDelete(DeleteBehavior.Restrict);
	// EF creates Unique Index for nullable fields
	mb.Entity<Question>()
		.HasIndex(q => q.AnsweredVariantId)
		.IsUnique(false);
	// create index instead of FK hence the cyclic dependency between Question and Variant
	mb.Entity<Question>()
		.HasIndex(q => q.CorrectVariantId)
		.IsUnique();
