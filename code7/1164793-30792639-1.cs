	foreach (var masterDataMember in masterdatamembers)
	{
		DataMember dataMember;
		if (datamembers.TryGetValue(masterDataMember.ID, out dataMember))
		{
			HashSet<string> newSet = new HashSet<string>();
			foreach (var version in masterDataMember.FoundVersions)
			{
				if (dataMember.Versions.Contains(version))
				{
					newSet.Add(version);
				}
			}
			masterDataMember.FoundVersions = newSet;
		}
		else
		{
			masterDataMember.FoundVersions.Clear();
		}
	}
