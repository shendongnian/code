    using System.Net;
    HttpResponseMessage response =
        await client.PostAsync(
                   uri.ToString(),
                   new StringContent(WebUtility.HtmlEncode(jsonString),
                                     Encoding.UTF8,
                                    "application/json"));
               
