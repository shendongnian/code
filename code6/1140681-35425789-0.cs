    private void movement(object sender, System.Windows.Input.KeyEventArgs key)
        {
            if ((Keys)KeyInterop.VirtualKeyFromKey(key) == Keys.Up)
            {
                x -= 20;
            } ...
