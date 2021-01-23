	public class FooController : Controller
	{
		public ActionResult Index()
		{
			// 1. Perform HTTP request to retrieve the JSON.
			var webClient = new WebClient();
			string rawJson = webClient.DownloadString("json-url");
			
			// 2. Parse the JSON.
			var jsonRootObject = JsonConvert.DeserializeObject<JsonRootObject>(rawJson);
			
			// 3. Map to your viewmodel
			var viewModel = new JsonViewModel
			{
				Items = jsonRootObject.Items.Select(i => new JsonItem
				{
					Name = i.Name,
					Unit = i.Unit
				}).ToList()
			};
            // 4. Return the model to your view
            return View(viewModel);
		}
	}
