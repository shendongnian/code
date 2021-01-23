    public Expression<Func<IPTORequest, bool>> BuildPendingOrderedSequencePTORequestFilter
                                                                 (IPublicReadContext context)
    {
        return
            r =>
               r.Activity.ActivitySteps.Where(s => s.Status == ActivityStepStatus.Pending)
                    .OrderBy(s => s.Sequence)
                    .FirstOrDefault()
                    .ActivityStepType == ActivityStepType.Approval;
    }
