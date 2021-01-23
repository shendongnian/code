	var caseList = context.Clases
		.Where(x => allowedCaseIds.Contains(x.CaseId))
		.AsEnumerable()									// Switch context
		.Select(x => new Case() {
			CaseId = x.CaseId,
			NotifierId = x.NotifierId,
			Notifier = x.NotifierId.HasValue
				? new Notifier() { Name = x.Notifier.Name }
				: null
		})
		.ToList();
