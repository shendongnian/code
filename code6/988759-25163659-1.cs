    public abstract class A
	{
		public virtual A Clone( )
		{
			// assuming your derived class contain a default constructor.
			return (A)Activator.CreateInstance(this.GetType( ));
		}
	}
