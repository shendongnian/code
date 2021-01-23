    protected void btnProcessFiles_Click(object sender, EventArgs e)
    {
        objDAO.SqlExec("SP_CLEAN");
        DirectoryInfo di = new DirectoryInfo(ConfigurationManager.AppSettings["XMLDir"]);
        foreach (FileInfo fl in di.GetFiles())
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(ConfigurationManager.AppSettings["XMLDir"] + fl.Name);
            string xml = doc.InnerXml;
            byte[] encodedString = Encoding.UTF8.GetBytes(xml);
            MemoryStream ms = new MemoryStream(encodedString);
            ms.Flush();
            ms.Position = 0;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(ms);
            XmlElement element = xmlDoc.DocumentElement;
            XmlNodeList nodes = element.ChildNodes;
            registerId = objDAO.SqlCall("SELECT NEWID()").Rows[0][0].ToString();
            XMLElementAnalyzer(nodes, "1", objDAO.SqlCall("SP_ADD_VALUE '" + registerId + "','1','1',1,'00000000-0000-0000-0000-000000000000'").Rows[0][0].ToString(), 1);
            registerId = String.Empty;
            if (new FileInfo(ConfigurationManager.AppSettings["XMLDir"] + "Done\\" + fl.Name).Exists)
            {
                new FileInfo(ConfigurationManager.AppSettings["XMLDir"] + "Done\\" + fl.Name).Delete();
                fl.MoveTo(ConfigurationManager.AppSettings["XMLDir"] + "Done\\" + fl.Name);
            }
            else
            {
                fl.MoveTo(ConfigurationManager.AppSettings["XMLDir"] + "Done\\" + fl.Name);
            }
        }
    }
    public void XMLElementAnalyzer(XmlNodeList nodes, String parent, String parentId, int instance)
    {
        String lastNode = String.Empty;
        String id = String.Empty;
        foreach (XmlNode node in nodes)
        {
            if (lastNode.Equals(String.Empty))
            {
                lastNode = node.Name;
            }
            else
            {
                instance += (node.Name.Equals(lastNode) ? 1 : 0);
            }
            String nodeId = String.Empty;
            if (!node.Name.Equals("#text"))
            {
                dt = objDAO.SqlCall("SP_CHECK_NODE '" + node.Name + "','" + parent + "'");
                if (dt.Rows.Count == 0)
                {
                    nodeId = objDAO.SqlCall("SP_ADD_NODE '" + node.Name + "','" + parent + "'").Rows[0][0].ToString();
                }
                else
                {
                    nodeId = dt.Rows[0][0].ToString();
                }
            }
            if (node.Attributes != null && node.Attributes.Count > 0)
            {
                id = objDAO.SqlCall("SP_ADD_VALUE '" + registerId + "','" + nodeId + "','" + nodeId + "'," + instance.ToString() + ",'" + parentId + "'").Rows[0][0].ToString();
                String attrId = String.Empty;
                foreach (XmlAttribute attr in node.Attributes)
                {
                    dt = objDAO.SqlCall("SP_CHECK_NODE '" + attr.Name + "','" + nodeId + "'");
                    if (dt.Rows.Count == 0)
                    {
                        attrId = objDAO.SqlCall("SP_ADD_NODE '" + attr.Name + "','" + nodeId + "'").Rows[0][0].ToString();
                    }
                    else
                    {
                        attrId = dt.Rows[0][0].ToString();
                    }
                    objDAO.SqlCall("SP_ADD_VALUE '" + registerId + "','" + attrId + "','" + attr.Value + "'," + instance.ToString() + ",'" + id + "'").Rows[0][0].ToString();
                }
            }
            if (node.Name.Equals("#text"))
            {
                id = objDAO.SqlCall("SP_ADD_VALUE '" + registerId + "','" + parent + "','" + node.Value + "'," + instance.ToString() + ",'" + parentId + "'").Rows[0][0].ToString();
            }
            if (node.ChildNodes.Count > 0)
            {
                if (node.Attributes == null || node.Attributes.Count == 0)
                    id = objDAO.SqlCall("SP_ADD_VALUE '" + registerId + "','" + nodeId + "','" + nodeId + "'," + instance.ToString() + ",'" + parentId + "'").Rows[0][0].ToString();
                XMLElementAnalyzer(node.ChildNodes, nodeId, id, instance);
            }
            if (node.InnerText.Equals("") && node.Attributes.Count == 0 && node.ChildNodes.Count == 0)
            {
                objDAO.SqlCall("SP_ADD_VALUE '" + registerId + "','" + nodeId + "','" + nodeId + "'," + instance.ToString() + ",'" + parentId + "'").Rows[0][0].ToString();
                objDAO.SqlCall("SP_ADD_VALUE '" + registerId + "','" + nodeId + "',''," + instance.ToString() + ",'" + parentId + "'").Rows[0][0].ToString();
            }
        }
    }
