	public async Task UpdateWerknemerCompetentieDetailAsync(
			int wnID, int WNC, CompetentieWerknemerDetail detail)
	{
		using (HttpClient client = new HttpClient())
		{
			string token = (string)HttpContext.Current.Session["token"];
			client.DefaultRequestHeaders.Authorization = 
					new AuthenticationHeaderValue("Bearer", token);
			var wn = GetWerknemerById(wnID);
			//var wnc = wn.CompetentiesWerknemer.Select(c => c)
			//									.Where(c => c.ID == WNC)
			//									.FirstOrDefault();
			
			detail.CompetentieWerknemerID = WNC;
			//wnc.CompetentieWerknemerDetail = detail;
			var url = String.Format(URL + "PutDetails?id=" + WNC);
			var json = JsonConvert.SerializeObject(detail, new JsonSerializerSettings()
			{
				 ReferenceLoopHandling = ReferenceLoopHandling.Ignore
			});         
			var response = await client.PutAsync(
				url, new StringContent(json, Encoding.UTF8, "application/json"));
		}
	}
	
