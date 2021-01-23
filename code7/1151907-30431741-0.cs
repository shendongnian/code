    var syncEntitiesArray = [{"EntityName":"Bulletins","LastSyncDate":"20150525_072418"},{"EntityName":"DatasetFilters","LastSyncDate":"20150525_072418"},{"EntityName":"Datasets","LastSyncDate":"20150525_072418"},{"EntityName":"DatasetItems","LastSyncDate":"20150525_072418"}]
    public class DateModel
    {
        public string EntityName { get; set; }
        public string LastSyncDate { get; set; }
    }
    IList<DateModel> myObject = JsonConvert.DeserializeObject<IList<DateModel>>(syncEntitiesArray);
    foreach (var obj in myObject)
      {
           string nodeName = obj.EntityName;
           string nodeValue = obj.LastSyncDate;
      }
