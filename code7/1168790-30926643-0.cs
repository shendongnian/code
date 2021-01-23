    var logger = _logger;
    if (data.Exception != null)
    {
       logger = logger.ForContext("Exception", data.Exception, true);
    }
    await Task.Run(() =>
        logger.ForContext("User", _loggedUser.Id)
              .Information(ControllerActionsFormat.RequestId_ExecutedAction,
                           data.RequestId, data.ActionName));
