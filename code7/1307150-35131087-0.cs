            string elements = string.Empty;
            XmlDocument xml = new XmlDocument();
            string xmlFilePath = Server.MapPath("XMLFile1.xml");//File Name
            xml.Load(xmlFilePath);
            XmlNodeList companyList = xml.GetElementsByTagName("subtitle");
            foreach (XmlNode node in companyList)
            {
                XmlElement companyElement = (XmlElement)node;
                 elements = companyElement.InnerText;
              
            }
            List<int> subIds = new List<int>();
            if (elements!="")
            {
                subIds = elements.Split(',').Select(int.Parse).ToList();    
            }
            ddlSub.DataSource = TagIds;
            ddlSub.DataBind();
            ddlSub.Items.Insert(0, new ListItem("--Select Subtitle--", "0"));
