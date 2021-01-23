               var session = await
                    context.SessionSet.Select(a => new
                    {
                        Host = a.Host,
                        Identifier = a.Identifier,
                        Destination = a.Destination,
                        Positions = a.Positions,
                        Sentinelles = a.Sentinelles,
                        Id = a.Id,
                        Code = a.Code,
                        Notifications = a.Notifications,
                        Status = a.Status,
                        Transportation = a.Transportation
                    }).FirstOrDefaultAsync(a => a.Identifier == sessionIdentifier);
                var result = await Json(session).ExecuteAsync(new CancellationToken());
