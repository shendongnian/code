        [HttpGet]
        public static IEnumerable<EmailContentModel> Get(int emailTemplateID, int? pageIndex, int? pageSize)
        {
            var clientManagementRepository = GetClientManagementRepository();
            var emailContents = clientManagementRepository.GetEmailContents(emailTemplateID, pageIndex, pageSize);
            return emailContents;
        }
