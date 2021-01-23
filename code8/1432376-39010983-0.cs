	public class User
	{
		public int UserId { get; set; }
		
		// Navigation properties
		public virtual ICollection<Payment> PaymentsFromUser { get; set; }
		public virtual ICollection<Payment> PaymentsToUser { get; set; }	
	}
	public class UserConfiguration
		: IEntityTypeConfiguration<User>
	{
		public UserConfiguration()
		{
			// Primary key
			HasKey(m => m.UserId);
			
			Property(m => m.PaymentId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
		}
	}
	public class Payment 
	{
		public int PaymentId { get; set; }
		public int FromUserId { get; set; }
		public int ToUserId { get; set; }
		
		// Navigation properties
		public virtual User FromUser { get; set; }
		public virtual User ToUser { get; set; }
	}
	public class PaymentConfiguration 
		: IEntityTypeConfiguration<Payment>
	{
		public PaymentConfiguration()
		{
			// Primary key
			HasKey(m => m.PaymentId);
					
			Property(m => m.PaymentId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
				
			// Relationship mappings
			HasRequired(m => m.FromUser)
				.WithMany(m => m.PaymentsFromUser)
				.HasForeignKey(m => m.FromUserId)
				.WillCascadeOnDelete(true);
				
			HasRequired(m => m.ToUser)
				.WithMany(m => m.PaymentsToUser)
				.HasForeignKey(m => m.ToUserId)
				.WillCascadeOnDelete(true);
		}
	}
