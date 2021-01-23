    CostingEvent targetEvent = repository.Query<CostingEvent>()
                                    .Include(ce => ce.ProposalSection)
                                    .Include(ce => ce.ProposalSection.Proposal)
                                    .Include(ce => ce.ProposalSection.Proposal.Costing)
                                    .FirstOrDefault(ce => ce.Id == targetId);
