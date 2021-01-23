    async Task CrawlAndDetectFlashAsync(LearningResource resource, string url, int depth)
    {
      using (var client = new HttpClient())
      using (var response = await client.GetAsync(url))
      {
        response.EnsureSuccessStatusCode();
        using (var content = response.Content)
        {
          var result = await content.ReadAsStringAsync(); // Result -> await
          resource.FlashRequired = result.Contains("application/x-shockwave-flash") || result.Contains("application/x-director") || result.Contains(".swf") ? 1 : 0;
          if (resource.FlashRequired == 0 && depth == 1)
          {
            var document = new HtmlDocument();
            document.LoadHtml(result);
            var links = document.DocumentNode.Descendants("a")
                        .Where(a => a.Attributes.Contains("class") && String.Equals(a.GetAttributeValue("class", string.Empty), "external"))
                        .Select(a => a.GetAttributeValue("href", null))
                        .Distinct()
                        .Where(u => !String.IsNullOrEmpty(u))
                        .ToList();
            if (links.Count > 0)
            {
              foreach (var link in links)
              {
                Task child = CrawlAndDetectFlashAsync(resource, link, 2);
                await child; // Wait -> await
              }
            }
          }
        }
      }
    }
