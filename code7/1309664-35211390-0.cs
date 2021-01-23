    var f = BindingContext.OutputFormatters.FirstOrDefault(
                formatter => formatter.GetType() ==
                             typeof (Microsoft.AspNet.Mvc.Formatters.JsonOutputFormatter))
            as Microsoft.AspNet.Mvc.Formatters.JsonOutputFormatter;
    if (f != null) {
        //f.SerializerSettings.Formatting = Formatting.Indented;
        f.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
    }
