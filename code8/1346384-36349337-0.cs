	user.PermissionSets.Union(user.Profile.PermissionSets).SelectMany(
		ps =>
			ps.Permissions.Select(
				p =>
					p.Controller + "." + p.Action));
