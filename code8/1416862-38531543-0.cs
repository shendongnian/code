    static void Main(string[] args)
    {
        //Start the Local server
        string url = @"http://localhost:8080/";
        using (WebApp.Start<Startup>(url))
        {
            Console.WriteLine(string.Format("Server running at {0}", url));
            //Instead of having the following two lines outside of this, 
            //I put it in here and it worked :)
            IHubContext hubContext = 
                     GlobalHost.ConnectionManager.GetHubContext<TestHub>();
            hubContext.Clients.All.NotifyAdmin_Signup();
            Console.ReadLine();
        }
    }
