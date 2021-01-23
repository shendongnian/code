    var membersQ=db.Members.Include(x=> x.Contact).Where(a=> a.Contact != null).Select(i=> new MemberViewModel(){
        Name = i.Contact.Name,
        ContactId= i.Contact.Id,
        CreatedDate= i.CreatedDate
    }).AsQueryable();
