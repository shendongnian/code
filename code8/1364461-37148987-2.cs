    using System.Collections.Generic;
    using RestSharp.Deserializers;
    public class ResourceList : List<ResourceUrl> {}
    [DeserializeAs(Name = "resourceURL")]
    public class ResourceUrl {
        [DeserializeAs(Name = "location")]
        public string Location { get; set; }
        [DeserializeAs(Name = "metaData1")]
        public string MetaData1 { get; set; }
        [DeserializeAs(Name = "metaData2")]
        public string MetaData2 { get; set; }
    }
    //(...)
    request.RootElement = null;
    request.XmlNamespace = null;
    var response = _restClient.Execute<ResourceList>(request);
