	public class MyClass
	{
	    public MyClass()
	    {
	        this.A = "a";
	        this.b = "b";
	    }
	    public string A { get; set; }
	    public string b { get; set; }
	}
	static void Main(string[] args)
	    {
	        var cts = new CancellationTokenSource();
	        MainAsync(args, cts.Token).Wait();
	    }
	    static async Task MainAsync(string[] args, CancellationToken token)
	    {
	        string baseAddress = "http://localhost:18207/api/values/GetMyClass";
	        using (var httpClient = new HttpClient())
	        {
	 
	            HttpResponseMessage response = await httpClient.GetAsync(baseAddress);
				response.EnsureSuccessStatusCode();
	             MyClass result = await response.Content.ReadAsAsync< MyClass>();
	        }
	    }
