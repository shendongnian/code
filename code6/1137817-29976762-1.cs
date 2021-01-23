        private void button1_Click(object sender, EventArgs e)
        {
            string xmlText = textBox1.Text;
            String exp = "//text()";
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(xmlText);
            //Writes the text out to a textbox
            foreach (XmlNode x in xml.SelectNodes(exp))
                textBox2.AppendText("(" + GetPath(x) + ", " + x.InnerText + ")\n");
        }
        string GetPath(XmlNode nd)
        {
            if (nd.ParentNode != null && nd.NodeType == XmlNodeType.Text)
            {
                return GetPath(nd.ParentNode);
            }
            else if (nd.ParentNode != null && nd.NodeType != XmlNodeType.Text)
            {
                //Is this really what it takes to get the index of an XmlNode????
                var index = nd.ParentNode.ChildNodes.Cast<XmlNode>().Select((e, i) => new { e, i }).Where(o => o.e == nd).FirstOrDefault().i;
                string path = GetPath(nd.ParentNode);
                path += (path != "") ? "/" : "";
                return string.Format("{0}{1}[{2}]", path, nd.Name, index);
            }
            else return "";
        }
