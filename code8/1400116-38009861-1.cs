    public string articleXMLTest()
    {
        string a = testtitle();
        string b = testStory();
        string c = "";
        string results = "";
    
        // Debug the length of your arrays. Im pretty sure they wont match.
        string[] aA = a.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        string[] bA = b.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        if (aA.Length == bA.Length)
        {
            for (int i = 0; i < aA.Length; i++)
            {
                DateTime dt = DateTime.Today;
    
                XDocument doc = new XDocument(
                    new XDeclaration("1.0", "gb2312", string.Empty),
                    new XElement("article",
                    new XElement("status", "Approved"),
                    new XElement("title", aA[i].ToString()),
                    new XElement("subtitle", aA[i].ToString()),
                    new XElement("synopsis", bA[i].ToString() + "..."),
                    new XElement("url", c),
                    new XElement("display_date", dt.ToShortDateString())
                ));
    
                results = results + Environment.NewLine + doc.ToString();
            }
            // Or set a breakpoint here to check if it reaches this return.
            return results;
        }
        // I guess you will end up here.
        return "Length of aA isnt matching length of bA";
    }
