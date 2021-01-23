    var summary = (from image in images
                   group image by new { image.ClientName, 
                                        image.PolicyType,
                                        BackupDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0)
                                                               .AddSeconds(image.BackupTime)
                                                               .ToString("yyyy-MM-dd")
                                      } into imageGroup
                   select new { ClientName = imageGroup.Key.ClientName, 
                                PolicyType = imageGroup.Key.PolicyType,
                                BakupDateTime = imageGroup.Key.BackupDateTime,
                                SumGBytes = imageGroup.Sum(s => s.KBytes) / 1048576.0,
                                AvgGBytes = imageGroup.Average(s => s.KBytes) / 1048576.0
                              }
                  ).ToList();
