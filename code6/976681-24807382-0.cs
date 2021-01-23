    public string GetMessageStatusDescription(int statusId)
    {
        using (var appContext = AppContext.GetContext())
        {
            var status = appContext.Message.FirstOrDefault(id => id.IdStatus == statusId);
            return status != null ? status.StatusDescription : string.Empty;
        }
    }
