			var MembersForDrop = 
				Db.Members
					.OrderBy(o => o.Sira)
					.Where(p=>p.MemberType == (MemberTypeForReeve)2)
					.Select(m => new SelectListItem() { Text = string.Format("{0}.{1}", m.Name, m.Surname), Value = m.Id});
					
			SelectList sl = new SelectList(MembersForDrop);
