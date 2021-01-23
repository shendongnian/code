        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            if(dontClose)
            {
                e.Cancel = true;
            }
            base.OnClosing(e);
        }
