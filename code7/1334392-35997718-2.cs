    public String LinkUrl(Sitecore.Data.Fields.LinkField lf)
    {
        switch (lf.LinkType.ToLower())
        {
          case "internal":
            // Use LinkMananger for internal links, if link is not empty
            return lf.TargetItem != null ? Sitecore.Links.LinkManager.GetItemUrl(lf.TargetItem) : string.Empty;
          case "media":
            // Use MediaManager for media links, if link is not empty
            return lf.TargetItem != null ? Sitecore.Resources.Media.MediaManager.GetMediaUrl(lf.TargetItem) : string.Empty;
          case "external":
            // Just return external links
            return lf.Url;
          case "anchor":
            // Prefix anchor link with # if link if not empty
            return !string.IsNullOrEmpty(lf.Anchor) ? "#" + lf.Anchor : string.Empty;
          case "mailto":
            // Just return mailto link
            return lf.Url;
          case "javascript":
            // Just return javascript
            return lf.Url;
          default:
            // Just please the compiler, this
            // condition will never be met
            return lf.Url;
        }
    }
    
    protected string writeBalloon(Item targetItem)
    {
            string balloonString = "";
            
            Sitecore.Data.Fields.LinkField linkfield = targetItem.Fields["Link"];
          
            balloonString += "<a class='balloon-link' href='" + LinkUrl(linkfield) + "'>";
            balloonString += "<div class='balloon'>";
            balloonString += "<h3>";
            balloonString += targetItem.Fields["Title"];
            balloonString += "</h3>";
            balloonString += "<p>";
            balloonString += targetItem.Fields["Text"];
            balloonString += "</p>";
            balloonString += "</div>";
            balloonString += "</a>";
            return balloonString;
    }
