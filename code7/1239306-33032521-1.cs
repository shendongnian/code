    HtmlDocument htmlDoc = new HtmlDocument();
    htmlDoc.Load(MyIO.bingPathToAppDir("Test data/testHTML.html"));
    HtmlNode j = htmlDoc.DocumentNode;
    foreach (HtmlNode node in j.ChildNodes)
    {
        checkNode(node);
    }
    
    static void checkNode(HtmlNode node)
    {
        foreach (HtmlNode n in node.ChildNodes)
        {
            if (n.HasChildNodes)
            {
                checkNode(n);
            }
            else
            {
                Console.WriteLine(n.InnerText);
            }
        }
    }
