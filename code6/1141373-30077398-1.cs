    class Sample
    {
        Outlook.Application GetApplicationObject()
        {
            Outlook.Application application = null;
            // Check whether there is an Outlook process running.
            if (Process.GetProcessesByName("OUTLOOK").Count() > 0)
            {
                // If so, use the GetActiveObject method to obtain the process and cast it to an Application object. Or close Outlook to open a new instance with a desired profile
                application = Marshal.GetActiveObject("Outlook.Application") as Outlook.Application;
                //!! Check if the application is using the right profile - close & reopen if necessary
            }
            else
            {
                // If not, create a new instance of Outlook and log on to the default profile.;
                application = new Outlook.Application();
                Outlook.NameSpace nameSpace = application.GetNamespace("MAPI");
                nameSpace.Logon("profilename", "", Missing.Value, Missing.Value);
                nameSpace = null;
            }
            // Return the Outlook Application object.
            return application;
        }
    }
