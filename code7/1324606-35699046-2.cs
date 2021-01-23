        Dim someReq As Net.WebRequest = Net.WebRequest.Create(someURL)
        Dim someResp As Net.WebResponse = someReq.GetResponse()
        Dim someStrm As IO.Stream = someResp.GetResponseStream()
        Dim someDoc As New Xml.XmlDocument
        someDoc.Load(someStrm)
        Dim xe As XElement = XElement.Parse(someDoc.InnerXml)
        Dim Dset As New DataSet
        Using reader As Xml.XmlReader = xe.CreateReader
            Dset.ReadXml(reader)
        End Using
        Debug.WriteLine(Dset.Tables.Count)
