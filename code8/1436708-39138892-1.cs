    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        xmldoc.Load("D:\\XML\\paths.xml");
            XmlNode node = xmldoc.DocumentElement.SelectSingleNode("/paths/sqlconnection");
            sqlconnect = node.InnerText;
            cn = new SqlCeConnection("Data Source=" + sqlconnect);
        Application.Run(new Form1(XmlNode));
    }
