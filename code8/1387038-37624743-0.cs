    [TestMethod]
    public async Task TestAllTheLinks()
    {
        BrowserWindow browserWindow = BrowserWindow.Launch("mywebsiteurl");
        HtmlTable table = new HtmlTable(browserWindow);
        table.SearchProperties.Add(HtmlTable.PropertyNames.Id, "tableId"); // or other search properties
        List<Exception> failureLinks = new List<Exception>();
        using (var client = new HttpClient())
        {
            for(int rowIndex = 0, max = table.RowCount; rowIndex < max; rowIndex++)
            {
                HtmlCell tableCell = table.GetCell(rowIndex, 0);
                HtmlHyperlink link = new HtmlHyperlink(tableCell);
                // are you sure you want to click?
                // how are you going to test rest of links if you nav away?
                Mouse.Click(link);
                // or would you rather just send an http request to that url to see if it is successful
                string href = link.Href;
                var result = await client.GetAsync(href);
                if (!result.IsSuccessStatusCode)
                {
                   failureLinks.Add(new Exception($"Link failed: {href}"));
                }
            }
        }
        if(failureLinks.Any()){
          throw new AggregateException(failureLinks);
        }
    }
