    private int peremennaya_slozenie;
    public void button_plus_Click(object sender, RoutedEventArgs e)
    {
        peremennaya_slozenie = Convert.ToInt32(ekran.Text);
    }
    private void button_rvno_Click(object sender, RoutedEventArgs e)
    {
        ekran.Text = Convert.ToString(peremennaya_slozenie + Convert.ToInt32(ekran.Text));
    }
