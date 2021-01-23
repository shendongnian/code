    string urlAddress = "http://www.theguardian.com/sport/2016/feb/23/test-cricket-farewells-brendon-mccullum";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string data = string.Empty;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;
                if (response.CharacterSet == null)
                {
                    readStream = new StreamReader(receiveStream);
                }
                else
                {
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                }
                data = readStream.ReadToEnd();
                response.Close();
                readStream.Close();
            }
            
            var hdoc = new HtmlDocument();
            hdoc.LoadHtml(data); 
            var articleNodes = hdoc.DocumentNode.SelectNodes(@"//p"); // the 'p' nodes contains the article text
            var quote ="Sinatra couldn’t stand the song. His daughter Tina once said that her father thought it was “self-serving and self-indulgent”. By the end of the ’70s he was in the habit of introducing it by explaining how little he liked it. “I hate this song. I hate this song!” he said before performing it at Atlantic City in 1979. “I got it up to here, this goddamn song.” Of course when Sinatra died, pretty much every single TV and radio news show played him out with My Way, “the most obvious, ";
            var article = string.Empty;
            foreach (HtmlNode node in articleNodes)
            {
                article += node.InnerText + " "; // added a whitespace so we dont mess up the text.
            }
            bool containsQuote = false || article.Contains(quote); // bool is true if the quote is in the article.
