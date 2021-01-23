	public class Text
	{
		public string FieldName { get; set; }  
		public string LanguageCode { getl set; }
		public string Description { get; set; }
		
		// Navigation properties
		public virtual Language Language { get; set; }
	}
	internal class TextMap
		: EntityTypeConfiguration<Text>
	{
		public TextMap()
		{
			// Primary key
			this.HasKey(m => new { m.FieldName, m.LanguageCode });
			
			this.Property(m => m.FieldName)
					.HasMaxLength(7)
					.IsFixedLength();
					
			this.Property(m => m.LanguageCode)
					.HasMaxLength(2)
					.IsFixedLength();
					
			// Properties
			this.Property(m => m.Description)
				.IsRequired()
				.HasMaxLength(50);						
			
			// Relationship mappings
			this.HasRequired(m => m.Language)
				.WithMany()
				.HasForeignKey(m => m.LanguageCode)
				.WillCascadeOnDelete(false);
		}
	}
