        private static string WindowsToIana(string windowsZoneId)
        {
            if (windowsZoneId.Equals("UTC", StringComparison.Ordinal))
                return "Etc/UTC";
            var tzdbSource = NodaTime.TimeZones.TzdbDateTimeZoneSource.Default;
            var tzi = TimeZoneInfo.FindSystemTimeZoneById(windowsZoneId);
            if (tzi == null) return null;
            var tzid = tzdbSource.MapTimeZoneId(tzi);
            if (tzid == null) return null;
            return tzdbSource.CanonicalIdMap[tzid];
        }
        private static string IanaToWindows(string ianaZoneId)
        {
            var utcZones = new[] { "Etc/UTC", "Etc/UCT", "Etc/GMT" };
            if (utcZones.Contains(ianaZoneId, StringComparer.Ordinal))
                return "UTC";
            var tzdbSource = NodaTime.TimeZones.TzdbDateTimeZoneSource.Default;
            // resolve any link, since the CLDR doesn't necessarily use canonical IDs
            var links = tzdbSource.CanonicalIdMap
                .Where(x => x.Value.Equals(ianaZoneId, StringComparison.Ordinal))
                .Select(x => x.Key);
            // resolve canonical zones, and include original zone as well
            var possibleZones = tzdbSource.CanonicalIdMap.ContainsKey(ianaZoneId)
                ? links.Concat(new[] { tzdbSource.CanonicalIdMap[ianaZoneId], ianaZoneId })
                : links;
            // map the windows zone
            var mappings = tzdbSource.WindowsMapping.MapZones;
            var item = mappings.FirstOrDefault(x => x.TzdbIds.Any(possibleZones.Contains));
            if (item == null) return null;
            return item.WindowsId;
        }
        private static string GetIanaTimeZone(double latitude, double longitude, DateTime date)
        {
            RestClient client;
            string location;
            RestRequest request;
            RestResponse response;
            TimeSpan time_since_midnight_1970;
            double time_stamp;
            string time_zone = "";
            try
            {
                const string GOOGLE_API = "https://maps.googleapis.com";
                const string GOOGLE_TIMEZONE_REQUEST = "maps/api/timezone/xml";
                client = new RestClient(GOOGLE_API);
                request = new RestRequest(GOOGLE_TIMEZONE_REQUEST,
                                            Method.GET);
                location = String.Format("{0},{1}",
                                           latitude.ToString(CultureInfo.InvariantCulture),
                                           longitude.ToString(CultureInfo.InvariantCulture));
                DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                time_since_midnight_1970 = date.ToUniversalTime() - origin;
                time_stamp = Math.Floor(time_since_midnight_1970.TotalSeconds);
                request.AddParameter("location", location);
                request.AddParameter("timestamp", time_stamp);
                request.AddParameter("sensor", "false");
                //request.AddParameter("key", yourgooglekey);
                response = (RestResponse)client.Execute(request);
                if (response.StatusDescription.Equals("OK"))
                {
                    XmlNode node;
                    XmlDocument xml_document = new XmlDocument();
                    xml_document.LoadXml(response.Content);
                    node = xml_document.SelectSingleNode(
                                "/TimeZoneResponse/time_zone_id");
                    if (node != null)
                    {
                        time_zone = node.InnerText;
                    }
                    else
                    {
                        
                    }
                }
                else
                {
                    
                }
            }
            catch (Exception ex)
            {
                
            }
            return time_zone;
        }
        public static DateTime? GetDateTimeFromCoordinates(DateTime? utc, double? latitude, double? longitude)
        {
            if (utc == null || latitude == null || longitude == null)
                return null;
            try
            {
                string iana_timezone = GetIanaTimeZone((double)latitude, (double)longitude, (DateTime)utc);
                if (string.IsNullOrWhiteSpace(iana_timezone))
                    return null;
                string time_zone = IanaToWindows(iana_timezone);
                TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById(time_zone);
                DateTime date = TimeZoneInfo.ConvertTimeFromUtc((DateTime)utc, tz);
                return date;
            }
            catch (Exception ex)
            {
                
                return null;
            }
        }
    }
    static void Main(string[] args)
    {
        double latitude = -11.2026920;
        double longitude = 17.8738870;
        DateTime uct = DateTime.UtcNow;
        
       DateTime? ret = GetDateTimeFromCoordinates(utc,latitude,longitude);
       
    }
