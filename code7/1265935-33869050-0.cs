    public class Response
    {
        public string error { get; set; }
        public string message { get; set; }
        public Dictionary<string, object> data { get; set; }
    }
	JsonConvert.SerializeObject(new Response
	{
		error = "0",
		message = "messages",
		data = new Dictionary<string, object>
		{
			{ "version", "sring" },
			{
				"1", new[]
				{
					1, 2, 3, 4
				}
			}
		}
	});
