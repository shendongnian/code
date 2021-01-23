     MailMessage mailMessage = new MailMessage();                
                mailMessage.From = new MailAddress(emailfrom); //from
                mailMessage.To.Add(new MailAddress(emailto)); //to
                mailMessage.Subject = subject;
                
                // check if message is meeting, if yes - attach meeting request as an alternateView
                if (isMeeting)
                {
                    System.Net.Mime.ContentType contentType = new System.Net.Mime.ContentType("text/calendar");
                    ct.Parameters.Add("method", "REQUEST");
                    ct.Parameters.Add("name", "meeting.ics");
                    string meetingInfo = MeetingRequestStrig(emailfrom, emailto, subject, bodycontent, location,
                        start.Value, end.Value, timezone, eventID, isCancel);
                    AlternateView avCal = AlternateView.CreateAlternateViewFromString(meetingInfo, contentType);
                    mailMessage.AlternateViews.Add(avCal);
                }
                else //otherwise sendgrid ignores calendar event and outlook has a simple html message
                {   
                    mailMessage.Body = bodycontent;
                }                              
                mailMessage.IsBodyHtml = html_enable; //if you need it
                // SMTP client, AppSettings.*** - from web.config in this case
                SmtpClient mSmtpClient = new SmtpClient(AppSettings.SMTPHost, Convert.ToInt32(AppSettings.SMTP_Port));
                NetworkCredential credentials = new System.Net.NetworkCredential(AppSettings.SMTPUsername,
                        AppSettings.SMTPPassword);
                    mSmtpClient.Credentials = credentials;
             
                //send 
                mSmtpClient.Send(mailMessage);
    private static string MeetingRequestString(string from, string to, string subject, string desc, string location, DateTime startTime, DateTime endTime, TimeZoneInfo timezone, int? eventID = null, bool isCancel = false)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("BEGIN:VCALENDAR");
            str.AppendLine("PRODID:-//Microsoft Corporation//Outlook 12.0 MIMEDIR//EN");
            str.AppendLine("VERSION:2.0");
            str.AppendLine(string.Format("METHOD:{0}", (isCancel ? "CANCEL" : "REQUEST")));
            str.AppendLine("BEGIN:VEVENT");
			
            int gapHours = GetTimeZoneOffsetHours(timezone);
            str.AppendLine(string.Format("DTSTART:{0:yyyyMMddTHHmmssZ}", startTime.AddHours(gapHours).ToUniversalTime()));
            str.AppendLine(string.Format("DTSTAMP:{0:yyyyMMddTHHmmss}", DateTime.Now));
            str.AppendLine(string.Format("DTEND:{0:yyyyMMddTHHmmssZ}", endTime.AddHours(gapHours).ToUniversalTime()));
            str.AppendLine(string.Format("LOCATION: {0}", location));
            str.AppendLine(string.Format("UID:{0}", (eventID.HasValue ? "blablabla" + eventID : Guid.NewGuid().ToString())));
            str.AppendLine(string.Format("DESCRIPTION:{0}", desc.Replace("\n", "<br>")));
            str.AppendLine(string.Format("X-ALT-DESC;FMTTYPE=text/html:{0}", desc.Replace("\n", "<br>")));
            str.AppendLine(string.Format("SUMMARY:{0}", subject));
            str.AppendLine(string.Format("ORGANIZER;CN=\"{0}\":MAILTO:{1}", from, from));
            str.AppendLine(string.Format("ATTENDEE;CN=\"{0}\";RSVP=TRUE:mailto:{1}", to, to));
            str.AppendLine("BEGIN:VALARM");
            str.AppendLine("TRIGGER:-PT15M");
            str.AppendLine("ACTION:DISPLAY");
            str.AppendLine("DESCRIPTION:Reminder");
            str.AppendLine("END:VALARM");
            str.AppendLine("END:VEVENT");
            str.AppendLine("END:VCALENDAR");
            return str.ToString();
        }
 
