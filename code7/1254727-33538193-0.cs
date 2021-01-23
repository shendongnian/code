    if (eligibility == null)
    {
         string validationMessage = "";
         validationMessage = "Please set eligibility for workflow permission";
         serviceName = null;
         permissionId = 0;
         return new CustomBusinessServices() { strMessage = validationMessage };
    }
    if (userLists.UserList.Contains(userId))
    {
         serviceName = strTxt[0].ToString() + ";Assyst.PanERP.Common.WorkFlowNotificationServices;" + strTxt[2].ToString();
         permissionId = workFlowServiceDetail;
         return userLists;
    }
