    public async Task<string> GenerateTemplate(string jsonData, string template)
    {
        var webView = new WebView();
        webView.Source = new Uri("ms-appx-web:///HTML/template.html");
        webView.DOMContentLoaded += async (o, e) =>
        {
            await webView.InvokeScriptAsync("convertFromJSON2HTML", new string[] { jsonData, template });
        };            
        string output = "";
        // Simple trick to convert event result to async result
        TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
        webView.ScriptNotify += (o, e) =>
        {
            output = e.Value;
            tcs.SetResult(true);
        };
        await tcs.Task;
        return output;
    }
