    var xml = @"<PostApplication_V6Result>
    &lt;xxxService&gt;
    &lt;Application&gt;
    &lt;Status&gt;PURCHASED&lt;/Status&gt;
    &lt;RedirectURL&gt;http://www.google.com?test=abc&amp;xyz=123&lt;/RedirectURL&gt;
    &lt;/Application&gt;
    &lt;/xxxService&gt;
    </PostApplication_V6Result>";
    var soap = XElement.Parse(xml);
    
    var rawContent = HttpUtility.HtmlDecode(soap.FirstNode.ToString().Trim())
    							.Replace("&", "&amp;");
    var content = XElement.Parse(rawContent);
    
