    using System.Collections.Generic;
    using System.Linq;
    // ....
    List<XmlDocument> l = new List<XmlDocument>();
    
    for(var i = 0; i < loopSize; ++i)
    {
         XmlDocument doc = GenerateTheDocument(i);
         l.Add(doc);
    }
    XmlDocument[] asArray = l.ToArray();
