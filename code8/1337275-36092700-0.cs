    XmlDocument xmlDoc = new XmlDocument();
    xmlDoc.Load("UserInfo.xml");
    XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/UsersInfo/UserInfo");
    foreach (XmlNode node in nodeList)
    {
        if (node.SelectSingleNode("Username").InnerText == username &&
                node.SelectSingleNode("Password").InnertText == password)
        {
            FirstName.Text = node.SelectSingleNode("FirstName").InnerText;
            LastName.Text = node.SelectSingleNode("LastName").InnerText;
            DateOfBirth.Text = node.SelectSingleNode("DateOfBirth").InnerText;
            Nationality.Text = node.SelectSingleNode("Nationality").InnerText;
            Passport.Text=node.SelectSingleNode("Passport").InnerText;
            Address.Text = node.SelectSingleNode("Address").InnerText;
            Phone.Text = node.SelectSingleNode("phone").InnerText;
        }
    }
