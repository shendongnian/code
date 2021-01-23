    var listWithDateTime = (from image in images
                            orderby image.ClientName ascending, 
                                    image.PolicyType ascending, 
                                    image.BackupTime ascending
                            select new { 
                                     ClientName = image.ClientName,
                                     PolicyType = image.PolicyType,
                                     GBytes = image.KBytes / 1048576.0,
                                     UnixTimestamp = image.BackupTime,
                                     NormalDate = new DateTime(1970, 1, 1, 0, 0, 0, 0)
                                                .AddSeconds(image.BackupTime)
                                                .ToString("MM/dd/yyyy", CultureInfo.InvariantCulture) 
                                   }
                           ).ToList();
