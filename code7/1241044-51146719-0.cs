    [HttpPost]
    public IHttpActionResult SaveDataFromRestToDB(string dataKey) {
         var parameters = this.Url.Request.GetQueryNameValuePairs();
         //parameters returns KeyValuePair<string, string>[2], containing values passed in Url Query
    }
