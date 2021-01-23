    using System.Windows.Controls.Primitives;
...
    public void Button_Click(object sender, EventArgs e)
    {
        var butt = sender as ToggleButton;
        if ((bool)butt.IsChecked)
            butt.Background = Brushes.Red;
        else
            butt.Background = Brushes.LightGray;
    }
