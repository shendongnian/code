        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.F1:
                    activeTracker= True;
                    break;
                case Key.F2:
                    activeTracker= False;
                    break;
                case Key.F3:
                    SendKeys.SendWait(txtMessage5.Text + "{ENTER}");
                    break;
        }
