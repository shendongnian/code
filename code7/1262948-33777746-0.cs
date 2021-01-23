    var answer = phaseRepository.Collection
        .OrderBy(p => p.PhaseNumber); // prepare to enforce "last two" requirement
		.GroupBy(p =>
             new { 
                p.Direction, 
                Momentum = p.Momentum == Mom.Undefined ? Mom.Time : p.Momentum
             })
		.SelectMany(g => g.Skip(g.Count() - 2)) // skip all but 2 from each group
        .OrderBy(p => p.PhaseNumber); // optional, to make verification easier
