        class Program
        {
            static void Main(string[] args)
            {
                GetRenderedWebPage("http://siderite.blogspot.com", TimeSpan.FromSeconds(5), output =>
                {
                    Console.Write(output);
                    File.WriteAllText("output.txt", output);
                });
                Console.ReadKey();
            }
    
            private static void GetRenderedWebPage(string url, TimeSpan waitAfterPageLoad, Action<string> callBack)
            {
                const string cEndLine= "All output received";
    
                var sb = new StringBuilder();
                var p = new PhantomJS();
                p.OutputReceived += (sender, e) =>
                {
                    if (e.Data==cEndLine)
                    {
                        callBack(sb.ToString());
                    } else
                    {
                        sb.AppendLine(e.Data);
                    }
                };
                p.RunScript(@"
    var page = require('webpage').create();
    page.viewportSize = { width: 1920, height: 1080 };
    page.onLoadFinished = function(status) {
        if (status=='success') {
            setTimeout(function() {
                console.log(page.content);
                console.log('" + cEndLine + @"');
                phantom.exit();
            }," + waitAfterPageLoad.TotalMilliseconds + @");
        }
    };
    var url = '" + url + @"';
    page.open(url);", new string[0]);
            }
        }
