    private string mStrXMLStk = Application.StartupPath + "\\Path.xml";
    private System.Xml.XmlDocument mXDoc = new XmlDocument();
    mXDoc.Load(mStrXMLStk);
    XmlNode XNode = mXDoc.SelectSingleNode("/Response");
    if (XNode != null)
    {
       if (XNode != null)
       {
           int IntChildCount = XNode.ChildNodes.Count;
           for (int IntI = 1; IntI <= 1; IntI++)
           {
                string LocalName = XNode.ChildNodes[IntI].LocalName;
                XmlNode Node = mXDoc.SelectSingleNode("/Response/" + LocalName);
                string _ip = Node.InnerText;
                MessageBox.Show("IP" + _ip);
           }
       }
    }
