         string API_KEY = "APIKEY";
			var jGcmData = new JObject();
			var jData = new JObject();
			jData.Add("message", message);
			jGcmData.Add("to", "/topics/global");
			jGcmData.Add("data", jData);
			var url = new Uri("https://gcm-http.googleapis.com/gcm/send");
			try
			{
				using (var client = new HttpClient())
				{
					client.DefaultRequestHeaders.Accept.Add(
						new MediaTypeWithQualityHeaderValue("application/json"));
					client.DefaultRequestHeaders.TryAddWithoutValidation(
						"Authorization", "key=" + API_KEY);
					Task.WaitAll(client.PostAsync(url,
						new StringContent(jGcmData.ToString(), Encoding.Default, "application/json"))
							.ContinueWith(response =>
							{
								Console.WriteLine(response);
								Console.WriteLine("Message sent: check the client device notification tray.");
							}));
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("Unable to send GCM message:");
				Console.Error.WriteLine(e.StackTrace);
			}
