     var data = ctx.ShiftSchedule.Where(m =>
                                            m.Company == company && m.EmployeeId == item.EmployeeId
                                        )
                                        .GroupBy(m =>
                                            new
                                            {
                                                m.EmployeeId,
                                                m.ShiftId
                                            })
                                        .Select(m =>
                                        new
                                        {
                                            EmployeeId = m.Key.EmployeeId,
                                            ShiftCode = m.Key.ShiftId,
                                            ShiftDate = m.Max(gg => gg.ShiftDate)
                                        }).ToList().OrderBy(x => x.ShiftDate).First();
