    //GET Home/Detail/5
    public async Task<ActionResult> Detail(int id) {
        var client = new HttpClient();
        client.BaseAddress = new Uri("http://localhost:19440/");
        client.DefaultRequestHeaders
            .Accept
            .Add(new MediaTypeWithQualityHeaderValue("application/json"));
        string endpoint = string.Format("api/Product1/{0}", id);
        var response= await client.GetAsync(endpoint);
        if (response.IsSuccessStatusCode) {
            var model = response.Content.ReadAsAsync<Product1Model>();
            return View(model);
        }
        return HttpNotFound();
    }
    //POST Home/Detail/5
    [HttpPost]
    public async Task<ActionResult> Detail(int id, Product1Model model) {
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri("http://localhost:19440/");
        string endpoint = string.Format("api/Product1/{0}", id);
        await client.PostAsJsonAsync<Product1Model>(endpoint, model)
            .ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
        return RedirectToAction("Index");
    }
