         foreach (HtmlNode nodeItem in doc.DocumentNode.Descendants("div").Where(p => p.GetAttributeValue("class", "def").Equals("main-class")))
             {
                 foreach (HtmlNode nodeAItem in nodeItem.Descendants("a"))
                 {
                    Debug.WriteLine(nodeAItem.GetAttributeValue("href", "def"));
                    foreach (HtmlNode nodeIMAGEitem in nodeAItem.Descendants("img"))
                     {
                         Debug.WriteLine(nodeIMAGEitem.GetAttributeValue("src", "def"));
                         Debug.WriteLine(nodeIMAGEitem.GetAttributeValue("alt", "def"));
                     }                    
                 }
              }
