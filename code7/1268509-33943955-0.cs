    public static void SubmitNewTutorial()
      {
        // Insert new tutorial method
        AddToDatabase();
    
        // Email notify anyone subscribed
        System.Web.Hosting.HostingEnvironment.QueueBackgroundWorkItem(ct => SendOutEmailNotifications());
    
        // Redirect to published tutorial page
        Redirect();
      }
