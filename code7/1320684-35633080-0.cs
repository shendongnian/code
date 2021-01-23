    var members = db.Contracts.Where(w=> w.Member != null).Select(i=> new MemberViewModel(){
     Name = i.Contact.Name,
     ContactId= i.Contact.Id,
     CreatedDate= i.CreatedDate
    }).AsQueryable());
