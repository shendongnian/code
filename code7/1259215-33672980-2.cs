    string sXPathT = ".//span[contains(@class,'group-label')]";
    string sXPathO = ".//span[contains(@class,'group-value')]";
    string xpathForDataId = "//div[@class='content' and @data-id='987654321']";
    HtmlAgilityPack.HtmlDocument Doc = new HtmlDocument();
    Doc.LoadHtml(strTestHTML);
    var specificNode = Doc.DocumentNode.SelectSingleNode(xpathForDataId);
    
    var vOddL = specificNode.SelectNodes(sXPathT);
    var vOddP = specificNode.SelectNodes(sXPathO);
    string GroupLabelBread = vOddL.ElementAt(0).InnerText.Trim();
    string GroupLabelMilk = vOddL.ElementAt(1).InnerText.Trim();
    string GroupValueBread = vOddP.ElementAt(0).InnerText.Trim();
    string GroupValueMilk = vOddP.ElementAt(1).InnerText.Trim();
    Console.WriteLine($"{GroupLabelBread}\t{GroupValueBread}");
    Console.WriteLine($"{GroupLabelMilk}\t{GroupValueMilk}");
