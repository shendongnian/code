     private static string RefineImageElement(string htmlContent)
     {
         var parser = new HtmlParser();
         var document = parser.ParseDocument(htmlContent);
    
         foreach (var element in document.All)
         {
             if (element.LocalName == "img")
             {
                 var newElement = document.CreateElement("v-img");
                 newElement.SetAttribute("src", element.Attributes["src"] == null ? "" : 
                  element.Attributes["src"].Value);
                 newElement.SetAttribute("alt", "Article Image");
    
                 element.Insert(AdjacentPosition.BeforeBegin, newElement.OuterHtml);
                 element.Remove();
              }
          }
          return document.FirstElementChild.OuterHtml;
    }
