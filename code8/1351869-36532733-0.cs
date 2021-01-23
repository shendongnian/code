	public static void SetChartPointsColor(this ExcelChart chart, int serieNumber, Color color)
	{
		var chartXml = chart.ChartXml;
		var nsa = chart.WorkSheet.Drawings.NameSpaceManager.LookupNamespace("a");
		var nsuri = chartXml.DocumentElement.NamespaceURI;
		var nsm = new XmlNamespaceManager(chartXml.NameTable);
		nsm.AddNamespace("a", nsa);
		nsm.AddNamespace("c", nsuri);
		var serieNode = chart.ChartXml.SelectSingleNode(@"c:chartSpace/c:chart/c:plotArea/c:barChart/c:ser[c:idx[@val='" + serieNumber + "']]", nsm);
		var serie = chart.Series[serieNumber];
		var points = serie.Series.Length;
		//Add reference to the color for the legend and data points
		var srgbClr = chartXml.CreateNode(XmlNodeType.Element, "srgbClr", nsa);
		var att = chartXml.CreateAttribute("val");
		att.Value = $"{color.R:X2}{color.G:X2}{color.B:X2}";
		srgbClr.Attributes.Append(att);
		var solidFill = chartXml.CreateNode(XmlNodeType.Element, "solidFill", nsa);
		solidFill.AppendChild(srgbClr);
		var spPr = chartXml.CreateNode(XmlNodeType.Element, "spPr", nsuri);
		spPr.AppendChild(solidFill);
		serieNode.AppendChild(spPr);
	}
