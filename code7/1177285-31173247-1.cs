    using (WordprocessingDocument template = WordprocessingDocument.Open(documentStream, true))
    {
        template.ChangeDocumentType(DocumentFormat.OpenXml.WordprocessingDocumentType.Document);
        MainDocumentPart mainPart = template.MainDocumentPart;
        mainPart.DocumentSettingsPart.AddExternalRelationship(
            "http://schemas.openxmlformats.org/officeDocument/2006/relationships/attachedTemplate",
            new Uri(templetAddr, UriKind.Absolute));
        ReplaceText(mainPart, "#PracticeName#", PracticeName);
        if(!String.IsNullOrEmpty(EducationDate))
            ReplaceText(mainPart, "#EducationDate#", EducationDate);
        if(!String.IsNullOrEmpty(MainContactInfo))
            ReplaceText(mainPart, "#MainContactInfo#", MainContactInfo);
        if(!String.IsNullOrEmpty(Address))
            ReplaceText(mainPart, "#Address#", Address);
    }
