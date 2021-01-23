    public Result<string> ConvertToHtml(string path)
            {
                var mammothJs = ReadResource("Mammoth.mammoth.browser.js") + ReadResource("Mammoth.mammoth.edge.js");
                
                var f = Edge.Func(mammothJs);
                var result = f(File.ReadAllBytes(path));
                Task.WaitAll(result);
    
                return ReadResult(result.Result);
            }
