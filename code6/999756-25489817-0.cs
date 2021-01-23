    private static nameSpace.BigClass.Class1 Request(JObject request)
    {
      nameSpace.BigClass.Class1 bigRequest = new BigClass.Class1();
      var internalList = new List<BigClass.Class1.SegmentClass1>();
      internalList.Add(new SegmentClass1
            {
                attrib1 = request.GetValue("attrib1").Value<DateTime>(),
                attrib2 = request.GetValue("attrib2").Value<string>(),
                attrib3 = request.GetValue("attrib3").Value<string>()
            });
      bigRequest.Segments = internalList;
      return bigRequest
    }
