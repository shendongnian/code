	var groupedBarges = riverBarges.Where(b => currentBarge.MileMarker + 0.5d >= b.MileMarker
											   && !b.IsGrouped)
								   .ToList();
								   
	BargeGroup group = new BargeGroup { Barges = groupedBarges };
	m_bargeGroups.Add(group);
	foreach (Barge barge in group.Barges)
	{
		barge.IsGrouped = true;
	}
