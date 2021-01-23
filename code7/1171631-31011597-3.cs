XmlNode subNode;
foreach (XmlNode node in xList)
{    
    subNode = node["service"];
    <b>if (subNode != null)</b>
    {
        serviceVal = subNode.InnerText;
    }
    else 
    {
        serviceVal = string.Empty;
    } 
}
