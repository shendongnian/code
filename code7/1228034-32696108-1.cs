    XmlDocument xdoc=new XmlDocument();
    xdoc.Load("XmlFile1.xml");
    
    //XmlNodeList node = xdoc.SelectSingleNodes("/Test1/Product/");
    var node = document.SelectNodes("/Test1/Product");
    foreach(XmlNode n in node )
    {
    ListItem l = new ListItem();
        l.Text = n.InnerXml.ToString();
        drpWerk.Items.Add(l);
    }
    drpProducts.DataBind();
