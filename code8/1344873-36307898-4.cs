     documents = db.tbl_TrnTicketDocument.Get(x => x.FK_TicketId == TicketId && x.IsActive == true).Select(s => new DocumentTypeModel()
            {
                DocumentTypeNameEnglish = s.tbl_MstDocumentType.DocumentTypeNameEnglish
            }).ToList().Distinct(new DocumentTypeModelComparer()).ToList();
----------
