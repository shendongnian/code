    var trainingView = (from b in db.DatatableTrainingHistorys
                                                        select new
                                                        {
                                                            TrainingName = b.TrainingName,
                                                            TrainingTime = b.TrainingTime,
                                                            Quota = b.Quota,
                                                            Location = b.Location,
                                                        }).AsQueryable();
