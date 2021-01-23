    public async Task<IList<News>> GetAllNewsByParams(DateTime from,
							string orderBy = "-published",
							DateTime to = new DateTime(),
							int page = 1, int category = 0)
		{
			var dict = new Dictionary<string, object> {
							{"from", from.ToString("s")},
							{"order_by", orderBy.ToString()},
							{"to", to.ToString("s")},
							{"page", page.ToString()}
						};
			if (category != 0)
			{
				dict.Add("category", category.ToString());
			}
			var res = await _client.GetList<News>(_config.NewsPath, dict);
			return res.Value;
		}
