    Option Infer On
    
    Private Function ImportoXML(ByVal PercorsoXML As String, ByVal ID As String) As String
    	Dim xdoc As XElement = XElement.Load(PercorsoXML, LoadOptions.PreserveWhitespace)
    	Dim ns As String = xdoc.Name.Namespace.NamespaceName
    	Dim elements = xdoc.Elements(XName.Get("PmtInf", ns)).Elements(XName.Get("DrctDbtTxInf", ns))
    	Dim ElencoValori = From lv2 In elements
    		Select New With {
    			Key .PmtId = lv2.Element(XName.Get("DrctDbtTx", ns)).Element(XName.Get("MndtRltdInf", ns)).Element(XName.Get("MndtId", ns)).Value,
    			Key .InstdAmt = lv2.Element(XName.Get("InstdAmt", ns)).Value;
    		}
    	Return ElencoValori.Where(Function(c) c.PmtId.EndsWith(ID)).FirstOrDefault().InstdAmt.ToString()
    End Function
