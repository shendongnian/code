    [HttpGet]
    public async Task<ActionResult> ShowContact(int loanId)
    {
        string json = string.Empty;
        List<Faq> FaqObject = null;  // Should probably be new List<Faq>
        var responseApi = await httpClient.GetAsync(string.Format("{0}/{1}", CommonApiBaseUrlValue, "faqs"));
        if (responseApi.IsSuccessStatusCode)
        {
            json = responseApi.Content.ReadAsStringAsync().Result;
            FaqObject = new JavaScriptSerializer().Deserialize<List<Faq>>(json);
        }
        var response = new
        {
            success = FaqObject != null,
            data = FaqObject
        };
        return View(new HelpCenterViewModel
        {
          ContactInfo=new ContactInfo {loanId},
          Faq=FaqObject
        });
    }
