	public class A
	{
		public string Data;
	}
	public class B : A { }
	public async Task<B> GetAsync()
	{
		return new B { Data = 
         (await new HttpClient().GetAsync("http://www.google.com")).ReasonPhrase };
	}
	public Task<A> WrapAsync()
	{
		return GetAsync().Cast(default(A));
	}
