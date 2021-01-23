    using (var sr = new StreamReader(endpointResponse.GetResponseStream())) {
        var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        var jsonObject = serializer.DeserializeObject(sr.ReadToEnd());
        return Json(jsonObject, JsonRequestBehavior.AllowGet);
    }
