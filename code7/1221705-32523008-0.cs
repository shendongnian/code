	public abstract class Wraper<T, TE>
		where T : Wraper<T, TE>, new()
	{
		public TE Value;
			
		public static implicit operator TE(Wraper<T, TE> value)
		{
			return value.Value;
		}
		public static implicit operator Wraper<T, TE>(TE value)
		{
			return new T { Value = value };
		}
	}
	public enum EFoo
	{
		A,
		B,
		C,
		D,
		E
	}
	;
	public class Foo : Wraper<Foo, EFoo>
	{
		public bool IsBla
		{
			get
			{
				return Value == EFoo.A || Value == EFoo.E;
			}
		}
	}
