    XmlDocument xmlDoc = new XmlDocument();
    XmlNode rootNode = xmlDoc.CreateElement("header1");
    xmlDoc.AppendChild(rootNode);
    
    XmlNode rootNode2 = xmlDoc.CreateElement("header2");
    rootNode.AppendChild(rootNode2);
    XmlNode accountNode = xmlDoc.CreateElement("fracc");
    accountNode.InnerText = Infracc;
    rootNode2.AppendChild(accountNode);
    
    XmlNode txnNode = xmlDoc.CreateElement("txncode");
    txnNode.InnerText = Intxncode;
    rootNode2.AppendChild(txnNode);
    
    XmlNode reasonNode = xmlDoc.CreateElement("reason");
    reasonNode.InnerText = Inreason;
    rootNode2.AppendChild(reasonNode);
    
    XmlNode timeoutNode = xmlDoc.CreateElement("timeout");
    timeoutNode.InnerText = Intimeout.ToString();
    rootNode2.AppendChild(timeoutNode);
    
    XmlNode rdateNode = xmlDoc.CreateElement("rdate");
    rdateNode.InnerText = Indate.ToString();
    rootNode2.AppendChild(rdateNode);
    
    XmlNode rtimeNode = xmlDoc.CreateElement("rtime");
    rtimeNode.InnerText = Intime.ToString();
    rootNode2.AppendChild(rtimeNode);
    
    XmlNode seqnoNode = xmlDoc.CreateElement("seqno");
    seqnoNode.InnerText = Inseqno.ToString();
    rootNode2.AppendChild(seqnoNode);
    
    XmlNode prefixNode = xmlDoc.CreateElement("prefix");
    prefixNode.InnerText = Inprefix.ToString();
    rootNode2.AppendChild(prefixNode);
    
    XmlNode msgtypeNode = xmlDoc.CreateElement("msgtype");
    msgtypeNode.InnerText = Inmsgtype;
    rootNode2.AppendChild(msgtypeNode);
    
    XmlNode sendtoNode = xmlDoc.CreateElement("sendto");
    sendtoNode.InnerText = Insendto;
    rootNode2.AppendChild(sendtoNode);
    
    XmlNode replytoNode = xmlDoc.CreateElement("replyto");
    replytoNode.InnerText = Inreplyto;
    rootNode2.AppendChild(replytoNode);
    
    xmlDoc.Save("boc.xml");
    xmlDoc.Load("boc.xml");
    xmlDoc.Save(Console.Out);           
    
    return xmlDoc;
