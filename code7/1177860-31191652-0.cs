    string str= "";
    XmlDocument xdoc = new XmlDocument();
    xdoc.Load("Your XML Path");
    XmlNodeList elements = xdoc.GetElementsByTagName("Info");
    for (int i = 0; i < elements.Count; i++)
    {
       str= elements[i].Attributes["name"].Value;
    }
    MessageBox.Show(str);
