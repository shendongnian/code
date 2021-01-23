    return _context.Logs.Where(x => x.ApplicationID == applicationId && (x.CreatedDate >= Date1Var && x.CreatedDate <= Date2Var))
                .OrderByDescending(x => x.ID)
                .Take(count)
                .Select(record => new LoggingLogic.entities.Log
                {
                    DataL = record.Data,
                    LogMessage = record.Message,
                    CreatedDate = record.CreateDate,
                    ApplicationName = record.Application.Name,
                    Environment = record.Application.Environment.EnvironmentName,
                    ID = record.ID
                });
