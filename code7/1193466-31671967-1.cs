    private void Border_MouseEnter(object sender, MouseEventArgs e)
    {
        this.ControlToHide.Visibility = System.Windows.Visibility.Hidden;
    }
    private void UserControl_MouseLeave(object sender, MouseEventArgs e)
    {
        this.ControlToHide.Visibility = System.Windows.Visibility.Visible;        
    }
