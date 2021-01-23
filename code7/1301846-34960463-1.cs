    DBContext = new ConsumerNomineeFormEntities();
            return (from f in DBContext.OfficeDetails
                    where SqlFunctions.DateDiff("day", f.Date, my.Date) > 90
                    where f.ChildCount < 5
                    select new EmployeeModel
                        {
                            XConsumer_Id = f.ConsumerNo_,
                            XApproved = f.Date,
                            XChildCount = f.ChildCount,
                            XTimeSpent = SqlFunctions.DateDiff("day", f.Date, my.Date)
                        }).ToList();
