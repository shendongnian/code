    Private Function ImportXML(PercorsoXML As String, ID As String) As String
        Dim xdoc As XElement = XElement.Load(PercorsoXML, LoadOptions.PreserveWhitespace)
        Dim ns As String = xdoc.Name.Namespace.NamespaceName
        Dim elements = xdoc.Elements(XName.Get("PmtInf", ns)).Elements(XName.Get("DrctDbtTxInf"))
        Dim ElencoValori = From lv2 In elements
                           Select PmtId = lv2.Element(XName.Get("DrctDbtTx", ns)) _
                               .Element(XName.Get("MndtRltdInf", ns)) _
                               .Element(XName.Get("MndtId", ns)).Value, InstdAmt _
                               = lv2.Element(XName.Get("InstdAmt", ns)).Value
        Return ElencoValori.Where(Function(c) c.PmtId.EndsWith(ID)).FirstOrDefault().InstdAmt.ToString()
    End Function
