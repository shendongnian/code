    var forMemberId = int.Parse(FrmSell.txt);
    var memberRealEstateList = 
        (from estate in FrmSell.EstateList
         from member in FrmSell.MembersList
         where member.MemberID == forMemberId && member.MemberID == estate.OwnerID
         select new MemberRealEstate() {
             MemberID  = member.MemberID,
             MemberName = member.FirstName + " " + member.LastName,
             EstateID = estate.EstateID,
             EstateType = estate.EstateType,
             EstatePrice = estate.EstatePrice,
             EstateArea  = estate.EstateArea 
         }).ToList();
