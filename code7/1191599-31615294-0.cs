    public async Task<ActionResult> Delete(int id)
    {
        string url = String.Format("api/user/{0}", id);
    
        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = new Uri("http://localhost:49474/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    
            HttpResponseMessage response = await client.DeleteAsync(url);
    
            return RedirectToAction("Index");
        }
    }
