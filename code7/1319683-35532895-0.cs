    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net.Http.Formatting;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Test
    {
        public class TestFormatter : MediaTypeFormatter
        {
            public TestFormatter()
            {
                SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("application/json"));
            }
    
            public override bool CanReadType(Type type)
            {
                return false;
            }
    
            public override bool CanWriteType(Type type)
            {
                return true;
            }
    
            public override Task WriteToStreamAsync(Type type, object value, System.IO.Stream writeStream, System.Net.Http.HttpContent content, System.Net.TransportContext transportContext)
            {
                JsonSerializer serializer = new JsonSerializer();
    
                serializer.ContractResolver = new CamelCasePropertyNamesContractResolver();
                serializer.Converters.Add(new TestConverter());
    
                return Task.Factory.StartNew(() =>
                {
                    using (JsonTextWriter jsonTextWriter = new JsonTextWriter(new StreamWriter(writeStream, Encoding.ASCII)) { CloseOutput = false })
                    {
                        serializer.Serialize(jsonTextWriter, value);
                        jsonTextWriter.Flush();
                    }
                });
            }
        }
    }
