	int possibillity = 1; //1=> all has business
						//2=> none has business
						//3=> some may have business  
	var meetings = 
		ctx.Meetings.where(m=> (possibillity==1 && m.Attendees.All(a=> ctx.Businsses.Any(x => x.Owner_Id == a.Person.Id)))
						|| (possibillity==2 && m.Attendees.All(a=> !ctx.Businsses.Any(x => x.Owner_Id == a.Person.Id)))	
						|| (possibillity==3 && 1==1));
