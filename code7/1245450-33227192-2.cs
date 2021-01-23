	public static class Ex
	{
		public static IEnumerable<Member<T>> SelectMembers<T>(this IEnumerable<T> @this)
		{
			if (@this == null || !@this.Any())
			{
				yield break;
			}
			else
			{
				for (var i = 0; i < @this.Count(); i++)
				{
					yield return new Member<T>(@this.Skip(i).First(), @this.Take(i).Concat(@this.Skip(i + 1)));
				}
			}
		}
	}
	
	public sealed class Member<T>
	{ 
	    private readonly T _Selected; 
	    private readonly IEnumerable<T> _Remainder; 
	
	    public T Selected { get { return _Selected; } } 
	    public IEnumerable<T> Remainder { get { return _Remainder; } } 
	
	    public Member(T Selected, IEnumerable<T> Remainder) 
	    { 
	        _Selected = Selected; 
	        _Remainder = Remainder;    
	    } 
	}
