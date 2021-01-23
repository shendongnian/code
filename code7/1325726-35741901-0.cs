    public class RawServices : Service
    {
        public object Any(Lead request)
        {
             var xml = request.RequestStream.ReadFully().FromUtf8Bytes();
    
             var map = new Dictionary<string, string>();
             var rootEl = (XElement)XDocument.Parse(xml).FirstNode;
    
             foreach (var node in rootEl.Nodes())
             {
                 var el = node as XElement;
                 if (el == null) continue;
                 map[el.Name.LocalName] = el.Value;
             }
    
             return new LeadResponse {
                 Results = map
             }
        }
    }
