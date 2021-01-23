    login = new NetworkCredential("wapsatest@gmail.com", "wapsatest123456");
    client = new SmtpClient("smtp.gmail.com");
    client.Port = Convert.ToInt32(587);
    client.EnableSsl = true;
    client.Credentials = login;
    msg = new MailMessage { From = new MailAddress("wapsatest" + "smtp.gmail.com".Replace("smtp.", "@"), "nWorks Employee", Encoding.UTF8) };
    msg.To.Add(new MailAddress("saurabh.pawar@nworks.co"));
    msg.Subject = "Requested for leave by "+comboboxEmployee.Text;
    
    //-------------------Code for your Email body---------------------
    string strBody = string.Empty;
    strBody += "///////////////List of dates coming from list box name selecteddates";
    strBody += Environment.NewLine;
    foreach (var item in lstDate)  // here "lstDate" is name of your list where you store all date.
    {
    	//strBody += item.ToShortDateString() + Environment.NewLine;
    	strBody += "Some text before date".
    	strBody += item.ToShortDateString() + " (" + item.DayOfWeek + ")";
    	strBody += "Some text after date".
    	strBody += "<br/>";
    }
    msg.Body = strBody;
    //----------------------------- Over -----------------------------
    
    msg.BodyEncoding = Encoding.UTF8;
    msg.IsBodyHtml = true;
    msg.Priority = MailPriority.Normal;
    msg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
    client.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);
    string userstate = "sending.......";
    client.SendAsync(msg, userstate);
