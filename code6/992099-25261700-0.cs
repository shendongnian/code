    private void buss_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
        TextBlock txt = (TextBlock)sender;
        MessageBox.Show(txt.Text);
    }
