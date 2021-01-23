	public class Language
	{
		public string Code { get; set; }
		public string Country { get; set; }
	}
	internal class LanguageMap
		: EntityTypeConfiguration<Language>
	{
		public LanguageMap()
		{
			// Primary key
			this.HasKey(m => m.Code);
			
			this.Property(m => m.Code)
					.HasMaxLength(2)
					.IsFixedLength();
					
			// Proeprties
			this.Property(m => m.Country)
				.IsRequired();
		}
	}
