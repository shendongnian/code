                public static string GetContactListIDByListName(string listname)
                {
        
                    feedData = string.Empty;
        
                    id = string.Empty;
                    name = string.Empty;
                    status = string.Empty;
                    modified_date = string.Empty;
                    created_date = string.Empty;
                    contact_count = 0;
        
        
                    Stream stream = null;
                    StreamReader streamReader = null;
        
                    var client = new RestClient(ccURL);
                    var request = new RestRequest("/v2/lists?modified_since=[DATE]&api_key=[API-KEY]", Method.GET);
                    request.AddHeader("Authorization", "Bearer [ACCESS-TOKEN]");
                    request.AddHeader("X-Originating-Ip", "[SERVER-IP]");
                    request.AddHeader("Accept", "application/json");
        
                    IRestResponse response = client.Execute(request);
                    feedData = response.Content;
        
                    // DESERIALIZE Mashery JSON Response
        
                    byte[] byteArray = Encoding.ASCII.GetBytes(feedData);
                    MemoryStream myStream = new MemoryStream(byteArray);
                    DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Mashery.GetAllListsDef[]));
                    object result = serializer.ReadObject(myStream);
                    Mashery.GetAllListsDef[] jsonObj = result as Mashery.GetAllListsDef[];
        
        
                    foreach (Mashery.GetAllListsDef myResult in jsonObj)
                    {
                        if (myResult.name.ToUpper().Equals(listname.ToUpper()))
                        {
                            return myResult.id.ToString();
                        }
                    }
        
                    return "";
        
                }
        
                // JSON Definition For [GET All Lists] End Point Method
                [Serializable, XmlRoot("GetAllListsDef"), DataContract(Name = "GetAllListsDef")]
                public class GetAllListsDef
                {
                    [XmlElement("id"), DataMember(Name = "id")]
                    public string id { get; set; }
        
                    [XmlElement("name"), DataMember(Name = "name")]
                    public string name { get; set; }
        
                    [XmlElement("status"), DataMember(Name = "status")]
                    public string status { get; set; }
        
                    [XmlElement("created_date"), DataMember(Name = "created_date")]
                    public string created_date { get; set; }
        
                    [XmlElement("modified_date"), DataMember(Name = "modified_date")]
                    public string modified_date { get; set; }
        
                    [XmlElement("contact_count"), DataMember(Name = "contact_count")]
                    public string contact_count { get; set; }
        
                }
