    public string RetrieveHolidayDatesFromSource() {
      return this.DoRetrieveHolidayDatesFromSourceAsync(sync: true).GetAwaiter().GetResult();
    }
    public Task<string> RetrieveHolidayDatesFromSourceAsync() {
      return this.DoRetrieveHolidayDatesFromSourceAsync(sync: false);
    }
    private async Task<string> DoRetrieveHolidayDatesFromSourceAsync(bool sync) {
      var result = await this.GetHolidayDatesAsync(sync);
      /** Do stuff **/
      var returnedResult  = this.TransformResults(result);
      return returnedResult;
    }
    private async Task<string> GetHolidayDatesAsync(bool sync) {
      using (var client = new WebClient()) {
        return sync
            ? client.DownloadString(SourceURI)
            : await client.DownloadStringTaskAsync(SourceURI);
      }
    }
