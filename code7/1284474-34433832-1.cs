    // store the sync context in the field of your form
    SynchronizationContext syncContext = SynchronizationContext.Current;
    // avoid the async void :)
    public async Task AppIsolatedStore_TestInMultiThread_LstResultShouldBeEqual()
    // make event handler async - this is the only exception for the async void use rule from above
    private async void Button_Click(object sender, RoutedEventArgs e)
    // asynchronically wait the result without capturing the context
    await Task.WhenAll(allTsk).ConfigureAwait(false).ContinueWith(
      t => {
        // you can move out this logic to main method
        syncContext.Post(new SendOrPostCallback(o =>
            {
                TstRst.Text = "Completed..";
            }));
      }
    );
