    protected override void OnBackKeyPress(CancelEventArgs e)
        {
            if (!isExit)
            {
                isExit = true;
                var toast = new ToastPrompt();
                toast.Message = "Press back again to exit?";
                toast.MillisecondsUntilHidden = 3000;
                toast.Completed += (o, ex) => { isExit = false; };
                toast.Show();
                e.Cancel = true;
            }
            else
            {
                NavigationService.RemoveBackEntry();
            }
        }
