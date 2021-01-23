    using System.Net;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    ...
    private async Task<JArray> GetRESTDataAsync(string uri)
    {
        var webRequest = (HttpWebRequest)WebRequest.Create(uri);
        var webResponse = (HttpWebResponse) await webRequest.GetResponseAsync();
        var reader = new StreamReader(webResponse.GetResponseStream());
        string s = await reader.ReadToEndAsync();
        return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<JArray>(s));
    }
