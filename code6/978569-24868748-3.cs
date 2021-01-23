    var dummyList = Enumerable
        .Range(0, 1)
        .Select(x => new
        {
            Id = 1,
            MemberSubGroupName = "",
            MemberGroupName = "",
            MemberGroupId = 1,
            SubGroupCode = "",
            StartDate = DateTime.Now,
            EndDate = DateTime.Now,
        })
        .ToList();
