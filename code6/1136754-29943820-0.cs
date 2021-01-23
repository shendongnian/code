    protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
    {
            base.OnBackKeyPress(e);
            if (NavigationService.CanGoBack)
            {
                while (NavigationService.RemoveBackEntry() != null)
                {
                    NavigationService.RemoveBackEntry();
                }
            }
     }
