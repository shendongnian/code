    viewModel.TicketDetails = db.TicketDetails
        .OrderByDescending(c => c.TicketDetailId)
        .Include(c => c.JunkPart)
        .Include(c => c.Part).ToList()
        .GroupBy(c => c.GenericOrderId)
        .Select(c => c.FirstOrDefault())
        .ToList(); //<--- Add this
