    [HttpPost]
    public void DataAvailable([FromBody]IDictionary<string, string> dataAvailable,
        [FromUri] string book, [FromUri] string riskType) {
        if(dataAvailable != null && dataAvailable.Contains("type"){
            var type = dataAvaliable["type"];
            if(type == "App.RRSRC.Feeds.DataAvailable"){
               DataAvailableNotification obj = createInstanceOf<DataAvailableNotification>(dataAvailable);
               DataAvailable(obj,book,riskType);
            } else if (type == "Service.Feeds.Expired") {
               ExpiredNotification obj = createInstanceOf<ExpiredNotification>(dataAvailable);
               DataAvailable(obj,book,riskType);
            }
        }
    }
    private void DataAvailable(DataAvailableNotification dataAvailable, string book, string riskType) {
    }
    
    private void DataAvailable(ExpiredNotification dataAvailable, string book, string riskType) {
    }
    private T createInstanceOf<T>(IDictionary<string, string> data) where T : class, new() {
        var result = new T();
        var type = typeof(T);
        //map properties
        foreach (var kvp in data) {
            var propertyName = kvp.Key;
            var rawValue = kvp.Value;
            var property = type.GetProperty(propertyName);
            if (property != null && property.CanWrite) {
                property.SetValue(result, rawValue );
            }
        }
        return result;
    }
