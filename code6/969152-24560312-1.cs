    private void AquilesPL_Load(object sender, EventArgs e)
    {
       var task = Task.Factory.StartNew(() => RunTask());
       SomeFunction1();
       SomeFunction2();
       // Disable your UI controls
       task.ContinueWith(t =>
       {
           // This won't read until the other task is done
           ReadFile();
           // Enable your UI controls here
       }, TaskScheduler.FromCurrentSynchronizationContext());
    }
