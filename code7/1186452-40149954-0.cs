    private async void Parsing(string website)
           {
               try
               {
                   HttpClient http = new HttpClient();
                   var response = await http.GetByteArrayAsync(website);
                   String source = Encoding.GetEncoding("utf-8").GetString(response, 0, response.Length - 1);
                   source = WebUtility.HtmlDecode(source);
                   HtmlDocument resultat = new HtmlDocument();
                   resultat.LoadHtml(source);
     
    
               List&lt;HtmlNode&gt; toftitle = resultat.DocumentNode.Descendants().Where
               (x =&gt; (x.Name == "div" &amp;&amp; x.Attributes["class"] != null &amp;&amp; x.Attributes["class"].Value.Contains("block_content"))).ToList();
     
               var li = toftitle[6].Descendants("li").ToList();
               foreach (var item in li)
               {
                   var link = item.Descendants("a").ToList()[0].GetAttributeValue("href", null);
                   var img = item.Descendants("img").ToList()[0].GetAttributeValue("src", null);
                   var title = item.Descendants("h5").ToList()[0].InnerText;
     
                   listproduct.Add(new Product()
                   {
                       Img = img,
                       Title = title,
                       Link = link
                   });
               }
     
           }
           catch (Exception)
           {
     
               MessageBox.Show("Network Problem!");
           }
     
       }
