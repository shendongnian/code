    public void readconnectionstring()
            {
                xmldoc.Load("D:\\XML\\paths.xml");
                XmlNode node = xmldoc.DocumentElement.SelectSingleNode("/paths/sqlconnection");
                sqlconnect = node.InnerText;
                cn = new SqlCeConnection("Data Source=" + sqlconnect);
            }
