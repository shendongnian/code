	var groupMembers = db.groupMember
		.Where(g => g.GroupCode == _sid)
		.OrderBy(g => g.LastName)
		.Select(g => new GroupMemberDTVM(){
			FirstName = g.FirstName,
			LastName = g.LastName,
			GroupMemberEmail = g.GroupMemberEmail,
		})
		.Distinct()
		.Skip(jtStartIndex)
		.Take(jtPageSize);
