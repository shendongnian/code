    public class MyEventArgs: EventArgs, IDeferralSource
    {
      private readonly DeferralManager _deferralManager;
      public MyEventArgs(DeferralManager deferralManager)
      {
        _deferralManager = deferralManager;
      }
      public bool Change { get; set; }
      public IDisposable GetDeferral() { return _deferralManager.GetDeferral(); }
    }
    public class MessageReceiver
    {
      protected async Task OnMyEventAsync()
      {
        if (MyEvent != null)
        {
          DeferralManager deferralManager = new DeferralManager();
          MyEventArgs e = new MyEventArgs(deferralManager);
          MyEvent(this, e);
          await deferralManager.WaitForDeferralsAsync();
        }
        if (e.Change)
          Console.WriteLine("Change occured");
      }
    }
    public class Form
    {
      private async void Mr_MyEvent(object sender, MyEventArgs e)
      {
        using (e.GetDeferral())
        {
          string s = await GetString();
          e.Change = true;
        }
      }
    }
