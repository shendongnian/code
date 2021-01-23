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
                var index = nd.ParentNode.ChildNodes.Cast<XmlNode>().ToList().IndexOf(nd);
                string path = GetPath(nd.ParentNode);
                path += (path != "") ? "/" : "";
                return string.Format("{0}{1}[{2}]", path, nd.Name, index);
            }
            else return "";
        }
