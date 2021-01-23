    public class DefaultController : Controller
    {
        public async ActionResult Index()
        {
            var idlist = new List<String>() { "123", "massive list of strings....", "789" };
            var xdoc = new XDocument();
            xdoc.Declaration = new XDeclaration("1.0", Encoding.Unicode.WebName, "yes");
            var xroot = new XElement("records");
            xdoc.Add(xroot);
            foreach (string id in idlist) {
                // Get types FOO -----------------------------------
                var foos = EnumerateItems(enumType.FOO);
                await foos.ForEachAsync(cr => {
                    var xe = new XElement("r");
                    // create XML 
                    xroot.Add(xe);
                });
                // Get types BAR -----------------------------------
                var bars = EnumerateItems(enumType.BAR);
                await foos.ForEachAsync(cr => {
                    var xe = new XElement("r");
                    // create XML 
                    xroot.Add(xe);
                });
            }
            return View(xdoc);
        }
        public IAsyncEnumerable<ResultItem> EnumerateItems(enumType itemType)
        {
            return new AsyncEnumerable<ResultItem>(async yield => {
                Boolean keepGoing = true;
                while (keepGoing) {
                    // 100 records max per call
                    var w = new WebServiceClient();
                    request.enumType = itemType;
                    // MUST BE ASYNC CALL
                    var response = await w.responseAsync();
                    foreach (ResultItem cr in response.ResultList)
                        await yield.ReturnAsync(cr);
                    keepGoing = response.moreRecordsExist;
                }
            });
        }
    }
