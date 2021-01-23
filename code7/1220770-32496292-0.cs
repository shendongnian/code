    //add a name for the route:
    
    [Route("GetEmailContents")]
    public static IEnumerable<EmailContentModel> GetEmailContents(int emailTemplateID, int? pageIndex, int? pageSize)
    {
        var clientManagementRepository = GetClientManagementRepository();
        var emailContents = clientManagementRepository.GetEmailContents(emailTemplateID, pageIndex, pageSize);
        return emailContents;
    }
