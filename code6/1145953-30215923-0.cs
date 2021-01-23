    List<TrailRemarkEntity> trailRemarks = (from a in auditData
                                group a by new {
                                    a.TrailRemarkId,
                                    a.TrailRemarkId,
                                    a.PreviousAudit,
                                    a.StrategicPriority,
                                    a.Observations,
                                    a.DocumentsReviewed
                                } into groupedData
                                select new TrailRemarkEntity()
                                {
                                    TrailRemarkId = groupedData.Key.TrailRemarkId ?? 0,
                                    PreviousAuditName = groupedData.Key.PreviousAudit,
                                    DocumentsReviewed = groupedData.Key.DocumentsReviewed,
                                    StrategicPriorityName = groupedData.Key.StrategicPriority,
                                    OtherAuditeesUserName = string.join("," , groupedData.Select(exp=>exp.OtherAuditees)),
                                    Observations = groupedData.Key.Observations
                                }).ToList();
