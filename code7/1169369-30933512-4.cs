    Task.Factory.StartNew(() =>
    {
           Dispatcher.Invoke(() => 
           {
              button.Enabled = false;
              button.Text = "new text";
           }
    });
          
