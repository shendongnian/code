    //using System.Xml.Linq;
    //using System.Linq;
    //xmlStr = your xml string
    var xDoc = XDocument.Parse(xmlStr);
    var nvs = xDoc.Descendants("nv");
    var nads = nvs.Select(nv => nv.Elements("nad").First().Value).ToList();
    var thirdRs = nvs.Select(nv => nv.Elements("r").ElementAt(2).Value).ToList();
