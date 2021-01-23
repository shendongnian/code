    IList<TicketListModel> TicketList = (from t in db.Tickets
                            join e in db.Employees on t.ID equals e.ID
                            select new TicketListModel
                            {
                                Number = t.Number,
                                RequestDate = t.RequestDate,
                                Applicant = e.Name,
                                ComName = ComLibs.Name,
                                ProbType = t.ProbType,
                                ProbDetail = t.ProbDetail,
                                Status = t.Status
                            }).ToList();
