    var data = new {
      KeyValue="805373069",
      Tel="0123456789",
      TargetID="43301",
      ServiceLevel="Y",
      TypeId="13505",
      DateTime=System.DateTime.Now.ToString("ddMMyyyyHHmmssffftt"),
      DbDateTime=System.DateTime.Now.ToString("ddMMyyyyHHmmssffftt")
    };
    var array=System.Web.Mvc.HtmlHelper.AnonymousObjectToHtmlAttributes(data)
      .Select(x=>new DATA {Name=x.Key,Value=(string)x.Value})
      .ToArray();
