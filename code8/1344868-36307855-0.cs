    List<DocumentTypeModel> documents = new List<DocumentTypeModel>();
    using (var db = new UnitOfWork())
    {
       documents = db.tbl_TrnTicketDocument.Get(x => x.FK_TicketId == TicketId && x.IsActive == true).Select(s => new DocumentTypeModel()
       {
       DocumentTypeNameEnglish = s.tbl_MstDocumentType.DocumentTypeNameEnglish
       }).ToList();
    
       documents = documents.GroupBy(x => x.DocumentTypeNameEnglish).Select(g => g.First());
    }
