    // click handler for vsto excel add-in
    private async void btnDownload_Click(object sender, RibbonControlEventArgs e)
    {
        btnDownload.Enabled = false;
        using (var client = new HttpClient())
        {
            var resp = await client.GetAsync("http://somepath.com/data.json");
            var statusCode = (int) resp.StatusCode;
            if (statusCode == 200)
            {
                var json = await resp.Content.ReadAsStringAsync();
                var jobj = JObject.Parse(json); // from the library I mention.
                // lookup docs on how to manipulate jobj
                // then make calls to excel api to affect spreadsheet from the json.
            }
        }
        btnDownload.Enabled = true;
    }
