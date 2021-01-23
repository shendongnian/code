    public TResult Handle(TCommand command) {
        var detail = new ProcessDetail {
            StartTime = DateTime.Now,
            RequestBody = HttpContext.Current.Request.RawUrl
        };
        dbContext.ProcessDetails.Add(detail);
        var result = _innerHandler.Handle(command);
        // The ResponseBody is not something you can set at this state.
        detail.EndTime = DateTime.Now;
        return result;
    }
