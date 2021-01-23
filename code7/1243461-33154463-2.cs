    var data = new {
      KeyValue="805373069",
      Tel="0123456789",
      TargetID="43301",
      ServiceLevel="Y",
      TypeId="13505",
      DateTime=System.DateTime.Now.ToString("ddMMyyyyHHmmssffftt"),
      DbDateTime=System.DateTime.Now.ToString("ddMMyyyyHHmmssffftt")
    };
    var array = data.GetType()
      .GetProperties()
      .Select(x=>new DATA{Name=x.Name,Value=(string)x.GetValue(data)})
      .ToArray();
