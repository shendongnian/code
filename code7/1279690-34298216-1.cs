    public async Task<ActionResult> RequestDocuments(string stamp1, string stamp2) {
      var task1 = this.DocumentsRequestService.RequestByStampAsync(stamp1);
      var task2 = this.DocumentsRequestService.RequestByStampAsync(stamp2);
      var documents = await Task.WhenAll(task1, task2);
      return new JsonResult(documents);
    }
