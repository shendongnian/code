    foreach (Principal p in grp.GetMembers(false))
                {
                   TimeSpan tidtilbage = timeToExpire.GetTimeRemainingUntilPasswordExpiration("cv.local", p.SamAccountName);
                    TimeSpan under14 = new TimeSpan(14, 00, 00, 00);
                    TimeSpan ikkeMinus10 = new TimeSpan(-10, 00, 00, 00);
                    sorted = grp.GetMembers(false)
                    .Select(x => new
                       {
                               tidtilbage = timeToExpire.GetTimeRemainingUntilPasswordExpiration("cv.local", p.SamAccountName),
                               lines = tidtilbage.ToString("%d") + " dag(e)" + " " + tidtilbage.ToString("%h") + " time(r)" + " - " + p.SamAccountName.ToUpper() + " - " + p.DisplayName + "\n\n"
                        })
                            .Where(x => x.tidtilbage < under14 && x.tidtilbage > ikkeMinus10)
                            .OrderBy(x => x.tidtilbage)
                            .Select(x => x.lines)
                            .ToArray();
                            i++;
                    
                    
                    
                }
