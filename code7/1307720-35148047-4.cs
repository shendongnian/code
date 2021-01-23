    void OpenFCmn_OnClick(object obj)
        {
            var tb = (TextBox) obj;
            tb.KeyDown += TbOnKeyDown;
        }
        private void TbOnKeyDown(object sender, KeyEventArgs keyEventArgs)
        {
            MessageBox.Show(keyEventArgs.Key.ToString());
            keyEventArgs.Handled = true;
        }
