    public class Model1Context : DbContext
	{
		public Model1Context()
			: base("name=Model1")
		{
			 
		}
		// For TPH
		public virtual DbSet<BaseBO> MainObjects { get; set; }
		// For TPT
		//public virtual DbSet<A> As { get; set; }
		//public virtual DbSet<B> Bs { get; set; }
		//public virtual DbSet<C> Cs { get; set; }
	}
	public class BaseBO
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
	public class A : BaseBO
	{
	}
	public class B : BaseBO
	{
	}
	public class C : BaseBO
	{
	}
 
