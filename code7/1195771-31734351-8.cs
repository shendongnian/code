    void HtmlFilter_ConvertingHtmlNode(object sender, ConvertingHtmlNodeEventArgs e)
    {
        if (e.HtmlNode is C1HtmlElement)
        {
            var elem = e.HtmlNode as C1HtmlElement;
    
            if (elem.Name.ToLower() == "img" && _clipboardImages != null && _clipboardImages.Count > _imageCounter)
            {
                if (!elem.Attributes.ContainsKey("src")) // key comparison is not case sensitive
                {
                    e.Parent.Children.Add(_clipboardImages[_imageCounter].Clone());
                    e.Handled = true;
                }
                _imageCounter++;
            }
        }
    }
