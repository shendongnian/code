		public class A
		{
			public virtual string ID { get; set; } // Primary key
			public IList<B> Bs { get; set; }
		}
		public class B
		{
			public virtual A A { get; set; } // Foreign key now expressed as reference to "parent" object instead of property containing key value
		}
