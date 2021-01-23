    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Net.Http.Formatting;
    using System.Net.Http.Headers;
    using System.IO;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Net;
    using System.Xml;
    
    namespace Take5.MediaTypeFormatters
    {
        public class XmlDocumentMediaTypeFormatter : MediaTypeFormatter
        {
            private static Type _supportedType = typeof(XmlDocument);
    
            public XmlDocumentMediaTypeFormatter()
            {
                SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/xml"));
            }
    
            public override bool CanReadType(Type type)
            {
                return type == _supportedType;
            }
    
            public override bool CanWriteType(Type type)
            {
                return type == _supportedType;
            }
    
            public override Task<object> ReadFromStreamAsync(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger)
            {
                var taskSource = new TaskCompletionSource<object>();
                try
                {
                    System.Diagnostics.Debug.Assert(false, "Not fully implemented, get doc to read from readStream.");
                    var doc = new XmlDocument();
                    taskSource.SetResult(doc);
                }
                catch (Exception e)
                {
                    taskSource.SetException(e);
                }
                return taskSource.Task;
            }
    
            public override Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, TransportContext transportContext)
            {
                var taskSource = new TaskCompletionSource<object>();
                try
                {
                    XmlDocument doc = (XmlDocument)value;
                    XmlWriter writer = XmlWriter.Create(writeStream, new XmlWriterSettings() { Indent = true });
                    doc.WriteContentTo(writer);
                    writer.Flush();
    
                    taskSource.SetResult(null);
                }
                catch (Exception e)
                {
                    taskSource.SetException(e);
                }
                return taskSource.Task;
            }
        }
    }
