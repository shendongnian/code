    public Page_Load()
    {
    if (!page.ispostback)
    {
       
       System.Threading.Timer TimerForSessionExpire = new System.Threading.Timer(TickForSessionExpire, null, 0, 6000*60); // check after every 1 minute
    }
    else
    {
       stopWatch.reset();
       stopWatch.start();
    }
    }
    public void TickForSessionExpire()
    {
       if (stopWatch.Elapsed.TotalMinutes>20)
       {
           Response.Redirect("login.aspx");
       }
    }
