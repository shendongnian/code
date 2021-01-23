    public void FormEvents_Submit(object sender, SubmitEventArgs e)
    {
        
        DateTime dateTime1 = DateTime.Now;
        var year1 = dateTime1.Year+1;
        var mon1 = dateTime1.Month;
        var day1 = dateTime1.Day;
        var hour1 = dateTime1.Hour;
        var min1 = dateTime1.Minute;
        var sec1 = dateTime1.Second;
       
        System.Windows.Forms.MessageBox.Show(Convert.ToString(year1));// To check
        var dateTime = new DateTime(year1, mon1, day1, hour1, min1, sec1, DateTimeKind.Local);
        var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        var unixDateTime = (dateTime.ToUniversalTime() - epoch).TotalSeconds;
        //DateTime.Parse(hour1);
        var UriBuilder = new UriBuilder("http://smsgateway.me/api/v3/messages/send/");
        var parameters = HttpUtility.ParseQueryString(string.Empty);
        parameters["email"] = MainDataSource.CreateNavigator().SelectSingleNode("/my:myFields/my:email", NamespaceManager).Value;
        parameters["password"] = MainDataSource.CreateNavigator().SelectSingleNode("/my:myFields/my:password", NamespaceManager).Value;
        parameters["device"] = MainDataSource.CreateNavigator().SelectSingleNode("/my:myFields/my:device", NamespaceManager).Value; ;
        parameters["number"] = MainDataSource.CreateNavigator().SelectSingleNode("/my:myFields/my:MobileNumber", NamespaceManager).Value;
        parameters["message"] = MainDataSource.CreateNavigator().SelectSingleNode("/my:myFields/my:SMS_TO_BE_SENT", NamespaceManager).Value; ;
       // parameters["send_at"] = "";
        parameters["expires_at"] = Convert.ToString(unixDateTime);
        UriBuilder.Query = parameters.ToString();
        //UriBuilder.Fragment = "some_fragment";
        Uri finalUrl = UriBuilder.Uri;
        var request = WebRequest.Create(finalUrl);
