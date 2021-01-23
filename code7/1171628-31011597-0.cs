XmlNode subNode;
foreach (XmlNode node in xList)
{    
    subNode = node["service"];
    <b>if(subNode != null)</b>
    {
        // do something with subNode.InnerText.ToString(); 
    }      
}
