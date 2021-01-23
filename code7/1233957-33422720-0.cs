    [HttpPost]
    public async Task<HttpResponseMessage> SaveEmail(NotificationRequest model)
    {
        var taskResult await Task.Run(() =>
        {
            var emailResult = _saveEmailNotification.Execute(model);
            return _saveFile.Execute(model, emailResult);
        }
        return Request.CreateResponse(HttpStatusCode.Created, taskResult);
    }
