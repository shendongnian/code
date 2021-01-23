    context.Users.Select(r => new 
            {
                UserId=r.UserId,
                Name = r.FirstName + " " + r.LastName,
                Connections = r.MappingsUser1.Select(m => m.User2)
					.Concat(r.MappingsUser2.Select(m => m.User1))
            })
