    db.AddInParameter(dbCommand, "@Application", DbType.String, escalation.Application);
    db.AddInParameter(dbCommand, "@EM", DbType.String, escalation.EM);
    db.AddInParameter(dbCommand, "@EscalationActions", DbType.String, escalation.EscalationActions);
    db.AddInParameter(dbCommand, "@ProblemStatement", DbType.String, escalation.ProblemStatement);
    db.AddInParameter(dbCommand, "@status", DbType.String, escalation.status);
    db.AddInParameter(dbCommand, "@UpdatedBy", DbType.String, escalation.UpdatedBy);
    db.AddInParameter(dbCommand, "@UpdatedTime", DbType.DateTime, escalation.UpdatedTime);
    db.AddInParameter(dbCommand, "@Impact", DbType.String, escalation.Impact);
