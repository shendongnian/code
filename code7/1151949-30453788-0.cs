    private async void ApprovePublicationCommandAction()
    {
       DisableView();
    
       await Task.Factory.StartNew(() =>
        {
          try
           {
             Send emails blah blah
