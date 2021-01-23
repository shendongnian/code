    public class MetadataHelper
    {
        public static Task WriteMetadataAsync(Stream stream, IEdmModel model, HttpConfiguration config, string odataRouteName)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/$metadata");
            request.ODataProperties().Model = model;
            request.ODataProperties().RouteName = odataRouteName;
            request.SetConfiguration(config);
            var payloadKinds = new List<ODataPayloadKind> { ODataPayloadKind.MetadataDocument };
            var xmlMediaType = new MediaTypeHeaderValue("application/xml");
            var formatter = new ODataMediaTypeFormatter(payloadKinds).GetPerRequestFormatterInstance(model.GetType(), request, xmlMediaType);
            var content = new StringContent(String.Empty);
            content.Headers.ContentType = xmlMediaType;
            return formatter.WriteToStreamAsync(model.GetType(), model, stream, content, null);
        }
    }
