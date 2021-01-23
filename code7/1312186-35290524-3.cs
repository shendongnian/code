    public IHttpActionResult Delete(int id)
    {
        return ExecuteCommand(() => {
            var command = new DeleteItemCommand() { Id = id };
            _deleteCommandHandler.Handle(command);
        });
    }
    private IHttpActionResult ExecuteCommand(Action action)
    {
        try
        {
            action.Invoke();
            //or: action();
        }
        catch (CommandHandlerResourceNotFoundException)
        {
            return HttpResponseException(HttpStatusCode.NotFound);
        }
        catch (CommandHandlerException)
        {
            return HttpResponseException(HttpStatusCode.InternalServerError);
        }
        return Ok();
    }
