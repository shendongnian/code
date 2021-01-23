    public DocumentType? GetDocTypeByString(string docType){
        switch (docType)
        {
           case "ID":
             return DocumentType.IdCard;
           case "PASS"
             return DocumentType.Passport;
           //and so on
           default: return null;
        }
    }
