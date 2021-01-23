          HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
          htmlDoc.OptionFixNestedTags = true;
          htmlDoc.Load(new StringReader(PageContent));
          if (htmlDoc.DocumentNode != null)
          {
            HtmlNodeCollection nodes = htmlDoc.DocumentNode.SelectNodes(XPath);
            // Work with nodes selected via XPath here
          }
