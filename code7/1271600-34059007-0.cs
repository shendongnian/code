    public override async Task OnSuspendingAsync(object s, SuspendingEventArgs e)
    {
       try
       {
         // tidy up app temporary folder on exit
         await ApplicationData.Current.ClearAsync(ApplicationDataLocality.Temporary);
       }
       catch { }
    
       await base.OnSuspendingAsync(s, e);
    }
