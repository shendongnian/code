	if(isStaging_)
	{
		//condition1
		where task.RevisionDateTime > startDateTime_
							&& task.RevisionDateTime <= endDateTime_
							&& task.AutoAuditNotes.ToLower() != auditString.ToLower()
							select task).ToList();
	}
	else
	{
		//condition2
		where task.RevisionDateTime > startDateTime_
							&& task.RevisionDateTime <= endDateTime_
							&& task.AutoAuditNotes.ToLower() != auditString.ToLower()
							select task).ToList();
	}
