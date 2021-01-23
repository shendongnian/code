    var viewModel = membershipTypes.Select(t => new SelectMembershipTypeViewModel
    {
        //Select appropriate Cost based on current month
        Cost = DateTime.Now.Month == t.ReducedMonth ? t.ReducedCost : t.Cost,
        ClubId = club.ClubId,
        Name = club.Name,              
        MembershipName = t.Type,
        MembershipType = t.MembershipTypeClassification.Type,
        MembershipTypeId = t.MembershipTypeId,
    });
