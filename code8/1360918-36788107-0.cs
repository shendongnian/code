    private SemaphoreSlim _lock = new SemaphoreSlim(1);
    private async void Browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) {
            await _lock.WaitAsync();
            try
            {
                //Do some stuff
            }
            catch (Exception ex)
            {
                //Handle ex
            }
            finally
            {
                _lock.Release();
            }
    }
