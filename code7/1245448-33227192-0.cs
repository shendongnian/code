	var aa = new[] { "A1", "A2", "A3", "A4" };
	var bb = new[] { "B1", "B2", "B3", "B4" };
	var cc = new[] { "C1", "C2", "C3", "C4" };
	var dd = new[] { "D1", "D2", "D3", "D4" };
	
	var query =
		from a in aa.SelectMembers()
		from b1 in bb.SelectMembers()
		from b2 in b1.Remainder.SelectMembers()
		from c1 in cc.SelectMembers()
		from c2 in c1.Remainder.SelectMembers()
		from c3 in c2.Remainder.SelectMembers()
		from d in aa.SelectMembers()
		select new []
		{
			a.Selected, b1.Selected, b2.Selected, c1.Selected,
			c2.Selected, c3.Selected, d.Selected,
		};
