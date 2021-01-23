	var lines = new HashSet<string>(
		File
			.ReadAllLines(path)
			.Select(line => line.Trim().ToLower())
			.Where(line => !string.IsNullOrWhiteSpace(line)));
	var matches =
		from plr in newPlayers
		let name = plr.Key.Name.ToLower()
		let userAccountName = plr.Key.UserAccountName.ToLower()
		where lines.Contains(name) || lines.Contains(userAccountName)
		select plr.Key;
	foreach (var plr in matches.ToArray())
	{
		TShock.Utils.ForceKick(plr, "Bad name. GO AWAY!");
		newPlayers.Remove(plr);
	}
