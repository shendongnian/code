    MailMessage msg = new MailMessage();
    string system_Area_Encoded = HttpContext.Current.Server.HtmlEncode(system_Area);
    string assigned_ToVal_Encoded = HttpContext.Current.Server.HtmlEncode(Assigned_ToVal);
    string taskStatus_Encoded = HttpContext.Current.Server.HtmlEncode(TaskStatus);
    string msgBody_Encoded = HttpContext.Current.Server.HtmlEncode(MsgBody);
    msg.Body = string.Format(@"<b>System Area :</b>{0}<br /><b>Assigned To : </b>{1}<br /><b>Status :</b><font color=#0000FF>{2}</font><br /><br><b>Description :</b> {3}", system_Area_Encoded, assigned_ToVal_Encoded, taskStatus_Encoded, msgBody_Encoded); 
