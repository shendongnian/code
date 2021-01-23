    public abstract class A
	{
		public abstract A Clone( );
	}
	public class B : A
	{
		public override A Clone( )
		{
			return new B( );
		}
	}
	public class C : A
	{
		public override A Clone( )
		{
			return new C( );
		}
	}
