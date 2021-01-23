	async void button1_Click(object sender, System.EventArgs e)
	{
		try
		{
			HttpClientHandler hnd = new HttpClientHandler();
			hnd.Credentials = new NetworkCredential("[apikey]", "");
			string res;
			using (var client = new HttpClient(hnd))
			{
				var responseText = await client.GetStringAsync("[endpoint]/products");
				using (MemoryStream stream = new MemoryStream())
				using (StreamWriter writer = new StreamWriter(stream))
				{
					writer.Write(responseText.Replace("<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n", string.Empty));
					writer.Flush();
					stream.Position = 0;
					XDocument doc = XDocument.Load(stream);
					res = JsonConvert.SerializeXNode(doc, Formatting.Indented, true);
				}
				var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(res);
				//Result.Text = data["products"].GetType().ToString() + Result.Text;
				Func<string, Task> creator_method = async (string id) =>
				{
					try
					{
						using (var newClient = new HttpClient(hnd)) // Create a new client to avoid your other one's token being consumed
						{
							var responseProd = await newClient.GetStringAsync($"[endpoint]/products/{id}");
							using (MemoryStream stream = new MemoryStream())
							using (StreamWriter writer = new StreamWriter(stream))
							{
								writer.Write(responseProd.Replace("<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n", string.Empty));
								writer.Flush();
								stream.Position = 0;
								XDocument doc = XDocument.Load(stream);
								res = JsonConvert.SerializeXNode(doc, Formatting.Indented, true);
							}
							var product_rawData = JsonConvert.DeserializeObject<Dictionary<string, object>>(res);
							var productData = (JObject)product_rawData["product"];
							try
							{
								views.Children.Add(new ProductXaml(productData["name"]["language"]["#cdata-section"].ToString(), float.Parse(productData["price"]["#cdata-section"].ToString().Replace('.', ',')), productData["id_default_image"]["@xlink:href"].ToString()));
							}
							catch (NullReferenceException nre)
							{
								views.Children.Add(new ProductXaml(productData["name"]["language"]["#cdata-section"].ToString(), float.Parse(productData["price"]["#cdata-section"].ToString().Replace('.', ',')), ""));
							}
						}
					}
					catch (Exception gex) { throw; }
				};
				foreach (var product in ((JObject)data["products"])["product"])
					try
					{
						Device.BeginInvokeOnMainThread(async () => { await creator_method.Invoke(product["@id"].ToString()); });
					}
					catch (TaskCanceledException tce) { continue; }
					catch (WebException we) { continue;}
			}
		}
		catch (HttpRequestException ex)
		{
			Result.Text = ex.Message;
		}
	}
