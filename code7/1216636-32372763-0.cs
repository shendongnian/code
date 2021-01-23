    (from workLogList in DataContext.tblWorkLogs
                 //join tickets in DataContext.tblTickets on workLogList.TicketId equals tickets.TicketId
                 //join project in DataContext.tblProjects on tickets.ProjectId equals project.ProjectId
                 //join states  in DataContext.tblWorkflowStates on tickets.Status equals states.StateId
                 where workLogList.AccountId == id
                 group workLogList by workLogList.WorkDate into data
                 select new TimesheetModel
                 {
                     TaskDate = data.Key,
                     TimesheetList = data.Select(x => new TimesheetListModel()
                     {
                         ProjectId = x.tblTicket.tblProject.ProjectId,
                         ProjectName = x.tblTicket.tblProject.Name,
                         TaskDate = x.WorkDate,
                         TimeWorked = x.TimeWorked,
                         Note = x.Note,
                         Task = TaskString(x.tblTicket.TicketId, x.tblTicket.Title, x.TaskTitle)
                     }
                     ).ToList()
                 });
