    using System.IO;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Xml;
    
    namespace WebApiTests.Controllers
    {
    	public class HomeController : ApiController
    	{
    		const string sampleData = "<?xml version=\"1.0\"?><catalog><book id=\"bk101\"><author>Gambardella, Matthew</author><title>XML Developer's Guide</title><genre>Computer</genre><price>44.95</price><publish_date>2000-10-01</publish_date><description>An in-depth look at creating applications with XML.</description></book></catalog>";
    		public HttpResponseMessage Get()
    		{
    			var doc = new XmlDocument();
    			doc.LoadXml(sampleData);
    
    			return new HttpResponseMessage()
    			{
    				RequestMessage = Request,
    				Content = new XmlContent(doc)
    			};
    		}
    	}
    
    	public class XmlContent : HttpContent
    	{
    		private readonly MemoryStream _Stream = new MemoryStream();
    
    		public XmlContent(XmlDocument document)
    		{
    			document.Save(_Stream);
    			_Stream.Position = 0;
    			Headers.ContentType = new MediaTypeHeaderValue("application/xml");
    		}
    
    		protected override Task SerializeToStreamAsync(Stream stream, System.Net.TransportContext context)
    		{
    			_Stream.CopyTo(stream);
    			var tcs = new TaskCompletionSource<object>();
    			tcs.SetResult(null);
    			return tcs.Task;
    		}
    
    		protected override bool TryComputeLength(out long length)
    		{
    			length = _Stream.Length;
    			return true;
    		}
    		protected override void Dispose(bool disposing)
    		{
    			if(_Stream != null)
    				_Stream.Dispose();
	    	}
    	}
    }
