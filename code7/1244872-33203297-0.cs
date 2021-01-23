    public void FindShades()
    {
        string exePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
        string filepath = exePath + @"\XML\Colours.xml";
        XElement MyData = XElement.Load(filepath);
        IEnumerable<XElement> data = MyData.XPathSelectElements("//Shade[@id='3']");
        int count = data.Count();                                 
    }
