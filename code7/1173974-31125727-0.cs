    using(XmlStateReader xr = new XmlStateReader(XmlReader.Create(@"C:\path-to-file.xml")))
    {
        var fmtr = new XmlIts1Formatter();
        fmtr.ValidateConformance = false;
        fmtr.GraphAides.Add(new ClinicalDocumentDatatypeFormatter());
        var parseResult = fmtr.Parse(xr, typeof(ClinicalDocument));
        // There is a variable called structure which will contain your
        var cda = parseResult.Structure as ClinicalDocument;
    } 
