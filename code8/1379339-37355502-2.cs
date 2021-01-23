    [HttpGet]
    public async Task<ActionResult> ShowContact(int loanId)
    {
        var responseApi = await httpClient.GetAsync(string.Format("{0}/{1}", CommonApiBaseUrlValue, "faqs"));
        if (responseApi.IsSuccessStatusCode)
        {
          return View(new HelpCenterViewModel
          {
            ContactInfo=new ContactInfo {loanId},
            Faq=new JavaScriptSerializer().Deserialize<List<Faq>>(
              responseApi.Content.ReadAsStringAsync().Result)
          });
        }
        return View(new HelpCenterViewModel
        {
          ContactInfo=new ContactInfo {loanId},
          Faq=new List<Faq>()
        });
    }
