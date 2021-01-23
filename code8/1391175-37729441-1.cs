    //DELETE Home/Delete/5
    [HttpDelete]
    public async Task<ActionResult> Delete(int id) {
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri("http://localhost:19440/");
        client.DefaultRequestHeaders
            .Accept
            .Add(new MediaTypeWithQualityHeaderValue("application/json"));
        string endpoint = string.Format("api/Product1/{0}", id);
        var responsive = await client.DeleteAsync(endpoint);
        if (responsive.IsSuccessStatusCode) {
            return RedirectToAction("Index");
        }
        return HttpNotFound();
    }
