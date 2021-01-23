     Uri uri = new Uri("your uri string");
     Windows.Web.Http.HttpClient client = new Windows.Web.Http.HttpClient();
     var value1 = new System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<string,string>>
     { 
         // your key value pairs
     };
     var response = await client.PostAsync(uri,new HttpFormUrlEncodedContent(value1));
     var result = await response.Content.ReadAsStringAsync();
