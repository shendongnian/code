    SelectedAudit = await _auditService.GetCurrentAudit();
    //AuditHistoryHeader = String.Format(Constants.ADMINVIEW_AUDITHISTORYHEADER, Audits.Count);
    SelectedAudit.ObjectState = ObjectState.Deleted;
    _auditService.Delete(SelectedAudit); // <-- This is a problem
    _unitOfWorkAsync.SaveChanges();
