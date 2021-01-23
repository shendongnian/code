    [HttpPost]
    public ActionResult SendRestRequest(decimal latitude, decimal longitude)
        {
                var stopwatch = new System.Diagnostics.Stopwatch();
                var timestamp = new System.Runtime.Extensions(); 
                    // fetch data (as JSON string)
                    var url = new Uri("https://maps.googleapis.com/maps/api/timezone/json?location=" + latitude + "," + longitude + "&timestamp=1331161200&key=ggkiki9009FF");
                    var client = new System.Net.WebClient();
                    var json = client.DownloadString(url);
                    // deserialize JSON into objects
                    var serializer = new JavaScriptSerializer();
                    var data = serializer.Deserialize<JSONOBJECT.Data>(json);
                    // use the objects
                    decimal DstOffset = data.dstOffset;
                    decimal RawOffset = data.rawOffset;
                    ViewBag.jsonDstOffset = data.dstOffset;
                    ViewBag.jsonRawOffset = data.rawOffset;
                    ViewBag.jsonStatus = data.status;
                    ViewBag.jsonTimeZoneId = data.timeZoneId;
                    ViewBag.jsonTimeZoneName = data.timeZoneName;
            return View();
        }
    }
