    var myList = JsonConvert.DeserializeObject<MyTempModel>(jsonResult);
    var model = new MyRealModel
    {
        StartTime = myList.StartTime,
        EndTime = myList.EndTime
    };
    foreach (var temp in myList.Countries)
    {
        // Deserialize the actual ContryVm.
        var obj = JsonConvert.DeserializeObject<CountryVM>(temp.Value.ToString());
        int key = 0;
        int.TryParse(temp.Key, out key);
        model.Add(key, obj);
    }
                
