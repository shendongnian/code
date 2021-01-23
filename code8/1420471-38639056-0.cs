    async Task AsyncLoop()
        {
            while (true)
            {
                string result = await LoadNextItem();
    Application.Current.Dispatcher.Invoke(new Action(() => {  lbl1.Content = result; }));
               
            }
        }
