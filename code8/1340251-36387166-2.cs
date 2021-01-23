	//Set the data range
	//chart.Series.Add("D17:D22", "B17:B22");
	//chart.Series.Add("P17:P22", "B17:B22");
	for (var i = 0; i < opt.Count; i++)
	{
		var datarange = sheet.Cells[$"Bar!D{17 + i},Bar!P{17 + i}"];
		var ser = chart.Series.Add(datarange.Address, $"B{17 + i}:B{17 + i}");
		ser.HeaderAddress = sheet.Cells[$"$B{17 + i}"];
	}
	//have to remove cat nodes from each series so excel autonums 1 and 2 in xaxis
	var chartXml = chart.ChartXml;
	var nsm = new XmlNamespaceManager(chartXml.NameTable);
	var nsuri = chartXml.DocumentElement.NamespaceURI;
	nsm.AddNamespace("c", nsuri);
	//Get the Series ref and its cat
	var serNodes = chartXml.SelectNodes("c:chartSpace/c:chart/c:plotArea/c:bar3DChart/c:ser", nsm);
	foreach (XmlNode serNode in serNodes)
	{
        //Cell any cell reference and replace it with a string literal list
		var catNode = serNode.SelectSingleNode("c:cat", nsm);
		catNode.RemoveAll();
		//Create the string list elements
		var ptCountNode = chartXml.CreateElement("c:ptCount", nsuri);
		ptCountNode.Attributes.Append(chartXml.CreateAttribute("val", nsuri));
		ptCountNode.Attributes[0].Value = "2";
	    var v0Node = chartXml.CreateElement("c:v", nsuri);
		v0Node.InnerText = "opening";
		var pt0Node = chartXml.CreateElement("c:pt", nsuri);
		pt0Node.AppendChild(v0Node);
		pt0Node.Attributes.Append(chartXml.CreateAttribute("idx", nsuri));
		pt0Node.Attributes[0].Value = "0";
		var v1Node = chartXml.CreateElement("c:v", nsuri);
		v1Node.InnerText = "closing";
		var pt1Node = chartXml.CreateElement("c:pt", nsuri);
		pt1Node.AppendChild(v1Node);
		pt1Node.Attributes.Append(chartXml.CreateAttribute("idx", nsuri));
		pt1Node.Attributes[0].Value = "1";
		//Create the string list node
		var strLitNode = chartXml.CreateElement("c:strLit", nsuri);
		strLitNode.AppendChild(ptCountNode);
		strLitNode.AppendChild(pt0Node);
		strLitNode.AppendChild(pt1Node);
		catNode.AppendChild(strLitNode);
	}
	pck.Save();
