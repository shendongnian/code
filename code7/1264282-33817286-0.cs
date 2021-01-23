    foreach (var item in blueListItemsLinq)
    {
    	label.Content = item.TextContent;  // "Olly Murs"
    	var child = item.FirstChild as AngleSharp.Dom.Html.IHtmlAnchorElement;
    	var text = child.Text;             // "Olly Murs"
    	var path = child.PathName;         // "/music/trackfinder.html"
    }
