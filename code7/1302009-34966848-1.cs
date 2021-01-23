        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.F1:
                    activateTracker = True;
                    break;
                case Key.F2:
                    activateTracker = False;
                    break;
                case Key.F3:
                    SendKeys.SendWait(txtMessage5.Text + "{ENTER}");
                    break;
        }
