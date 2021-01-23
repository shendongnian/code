    public IHttpActionResult BankHolidays()
        {
            var rawJson = string.Empty;
            using (var webClient = new WebClient())
            {
                webClient.Encoding = Encoding.UTF8; // Expected Content-Type response is "application/json; charset=utf-8"
                rawJson = webClient.DownloadString("https://www.gov.uk/bank-holidays.json");
            }
            dynamic json = JsonConvert.DeserializeObject<dynamic>(rawJson);
            return Ok(json);
        }
