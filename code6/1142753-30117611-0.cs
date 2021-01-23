    public string DocumentType GetDocTypeByString(string docType) 
    {
        DocumentType result;
        if(!TryGetDocTypeByString(out result)) throw new ArgumentException("docType");
        return result;            
    }
    public bool TryGetDocTypeByString(string docType, out DocumentType result) 
    {
        // You should probably store this as a static member of your class
        var mapping = new Dictionary<string, DocumentType>() {
             { "ID", DocumentType.IdCard }
             ...
        };
        return mapping.TryGetValue(docType, out result);
    }
