    private Models.Priority CastPriority(ViewModels.TicketVM.Priority value)
    {
        Models.Priority priority = Models.Priority.Low;
        Enum.TryParse<Models.Priority>(value.ToString(), out priority);
        return priority;
    }
