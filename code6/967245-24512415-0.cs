    public class MyImageTagProcessor : IHTMLTagProcessor {
        void IHTMLTagProcessor.EndElement(HTMLWorker worker, string tag) {
            //No used
        }
        void IHTMLTagProcessor.StartElement(HTMLWorker worker, string tag, IDictionary<string, string> attrs) {
            if (!attrs.ContainsKey(HtmlTags.WIDTH)) {
                //Do something special here
                attrs.Add(HtmlTags.WIDTH, "400px");
            }
            if (!attrs.ContainsKey(HtmlTags.HEIGHT)) {
                //Do something special here
                attrs.Add(HtmlTags.HEIGHT, "400px");
            }
            worker.UpdateChain(tag, attrs);
            worker.ProcessImage(worker.CreateImage(attrs), attrs);
            worker.UpdateChain(tag);
        }
    }
