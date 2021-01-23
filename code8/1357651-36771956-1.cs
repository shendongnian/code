	if (pubProj.Tasks != null && pubProj.Tasks.Count > 0)
	{
		tempProj.BaseEndDate = pubProj.Tasks[0].BaselineFinish;
		tempProj.BaseStartDate = pubProj.Tasks[0].BaselineStart;
		tempProj.BaselineDuration = (pubProj.Tasks[0].BaselineDuration != null && pubProj.Tasks[0].BaselineDuration.Length > 2) ? Convert.ToInt16(Convert.ToDecimal(pubProj.Tasks[0].BaselineDuration.Remove(pubProj.Tasks[0].BaselineDuration.Length - 1))) : 0;
		tempProj.FinishVariance = (pubProj.Tasks[0].FinishVariance != null && pubProj.Tasks[0].FinishVariance.Length > 2) ? Convert.ToInt16(Convert.ToDouble(pubProj.Tasks[0].FinishVariance.Remove(pubProj.Tasks[0].FinishVariance.Length - 1))) : 0;
	}
	else
	{
		tempProj.BaselineDuration = 0;
		tempProj.FinishVariance = 0;
	}
