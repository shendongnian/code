         public class DataClass
                {
                    public string email { get; set; }
                    public string sg_event_id { get; set; }
                    public string sg_message_id { get; set; }
                    public int timestamp { get; set; }
                    
                     [JsonProperty("smtp-id")]
                    public string smtp { get; set; }
                     [JsonProperty("event")]
                       public string eve { get; set; }
                    public List<string> category { get; set; }
                    public string id { get; set; }
                    public string purchase { get; set; }
                    public string uid { get; set; }
                }
    
    
    
    This code is from a console app test:
    
    
                   string json = "{";
        json += "\"email\":\"john.doe@sendgrid.com\"" + ",";
        json +="\"sg_event_id\":\"VzcPxPv7SdWvUugt-xKymw\"" + "," ;
        json += "\"sg_message_id\":\"142d9f3f351.7618.254f56.filter-147.22649.52A663508.0\"" + ",";
       json += "\"timestamp\":1386636112" + ",";
       json += "\"smtp-id\":\"<142d9f3f351.7618.254f56@sendgrid.com>\"" + ",";
       json += "\"event\":\"processed\"" + ",";
       json += "\"category\":[\"category1\",\"category2\",\"category3\"]" + ",";
       json += "\"id\":\"001\",\"purchase\":\"PO1452297845\",\"uid\":\"123456\"" ;
       json +="}";
    
                DataClass data = JsonConvert.DeserializeObject<DataClass>(json);
    
                Console.Read();
