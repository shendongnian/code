    public class Model<TKey, TUserKey> where TUserKey : struct
	{
		public virtual TKey Id { get; set; }
		public virtual TUserKey UserId { get; set; }
		public virtual TUserKey? NullableUserId	{ get; set; }	
	}
	public class Model2<TKey, TUserKey> where TUserKey : class
	{
		public virtual TKey Id { get; set; }
		public virtual TUserKey UserId { get; set; }
		public virtual TUserKey NullableUserId { get; set; }
	}
