    List<jobSteps> lastStepOfJob =
		jobStepCollection
		.SelectMany(x => x.jobCollection.Select(y => Tuple.Create(y, x)))
		.Aggregate(
			new Dictionary<int, Tuple<jobs, jobSteps>>(),
			(memo, value) =>
			{
				if (memo.ContainsKey(value.Item1.jobID))
				{
					if (memo[value.Item1.jobID].Item2.stepOrder < value.Item2.stepOrder)
					{
						memo[value.Item1.jobID] = value;
					}
				}
				else
				{
					memo.Add(value.Item1.jobID, value);
				}
				return memo;
			})
		.Select(x => new { Job = x.Value.Item1, JobStep = x.Value.Item2 })
		.GroupBy(x => x.JobStep.stepOrder)
		.Select(x => new { JobStep = x.First().JobStep, Jobs = x.Select(y => y.Job) })
		.Select(x => new jobSteps()
		{
			stepDescription = x.JobStep.stepDescription,
			stepID = x.JobStep.stepID,
			stepOrder = x.JobStep.stepOrder,
			jobCollection = x.Jobs.OrderBy(y => y.jobID).Select(y => new jobs() { jobID = y.jobID, jobName = y.jobName }).ToList()
		})
		.OrderBy(x => x.stepOrder)
		.ToList();
