    private void button1_Click(object sender, EventArgs e)
    {
        string name = this.txtName.Text;
        string occupation = this.txtOccupation.Text;
        string dob = this.txtDob.Text;
        string nic = this.txtNic.Text;
        double id = double.Parse(this.lblID.Text);
        // XML file path.
        string xmlPath = "E:/Data.xml";
        XmlDocument xmlDoc = new XmlDocument();
        // If specified file does not exist, create a new one.
        if (!File.Exists(xmlPath))
        {
            XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", "yes");
            XmlElement rootNode = xmlDoc.DocumentElement;
            xmlDoc.InsertAfter(xmlDeclaration, rootNode);
            XmlNode parentNode = xmlDoc.CreateElement("Users");
            XmlNode subNode = xmlDoc.CreateElement("User");
            XmlAttribute nameAtt = xmlDoc.CreateAttribute("Name");
            nameAtt.Value = name;
            XmlAttribute occupationAtt = xmlDoc.CreateAttribute("Occupation");
            occupationAtt.Value = occupation;
            XmlAttribute dobAtt = xmlDoc.CreateAttribute("Date_Of_Birth");
            dobAtt.Value = dob;
            XmlAttribute nicAtt = xmlDoc.CreateAttribute("NIC");
            nicAtt.Value = nic;
            XmlAttribute idAtt = xmlDoc.CreateAttribute("ID");
            idAtt.Value = id.ToString();
            subNode.Attributes.Append(nameAtt);
            subNode.Attributes.Append(occupationAtt);
            subNode.Attributes.Append(dobAtt);
            subNode.Attributes.Append(nicAtt);
            subNode.Attributes.Append(idAtt);
            xmlDoc.AppendChild(parentNode);
            parentNode.AppendChild(subNode);
            // Save new XML file.
            xmlDoc.Save(xmlPath);
        }
        // If specified file exists, read and update it.
        else
        {
            // Open existing XML file.
            xmlDoc.Load(xmlPath);
            // Set to true if current name is already found in the XML file,
            // of course it should be better to check the ID instead the name,
            // supposing that ID is unique.
            bool nameFound = false;
            // Get all "User" nodes and check if one of them already contains
            // the specified name.
            foreach (XmlNode user in xmlDoc.SelectNodes("Users/User"))
            {
                if (user.Attributes.GetNamedItem("Name").Value == name)
                {
                    nameFound = true;
                    break;
                }
            }
            // If the name is not already in the file, insert a new user
            // with that name.
            if (nameFound == false)
            {
                XmlNode subNode = xmlDoc.CreateElement("User");
                XmlAttribute nameAtt = xmlDoc.CreateAttribute("Name");
                nameAtt.Value = name;
                XmlAttribute occupationAtt = xmlDoc.CreateAttribute("Occupation");
                occupationAtt.Value = occupation;
                XmlAttribute dobAtt = xmlDoc.CreateAttribute("Date_Of_Birth");
                dobAtt.Value = dob;
                XmlAttribute nicAtt = xmlDoc.CreateAttribute("NIC");
                nicAtt.Value = nic;
                XmlAttribute idAtt = xmlDoc.CreateAttribute("ID");
                idAtt.Value = id.ToString();
                subNode.Attributes.Append(nameAtt);
                subNode.Attributes.Append(occupationAtt);
                subNode.Attributes.Append(dobAtt);
                subNode.Attributes.Append(nicAtt);
                subNode.Attributes.Append(idAtt);
                xmlDoc.SelectSingleNode("Users").AppendChild(subNode);
                xmlDoc.Save(xmlPath);
            }
        }
    }
