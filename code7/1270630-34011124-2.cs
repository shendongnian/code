    private void Button_Click_2(object sender, RoutedEventArgs e) //veri
    {
        int num;
        if (!int.TryParse(BoiteChiffre.Text, out num))
            return;
        if (num < random1)
        {
            MessageBox.Show("Too low");
        }
        if (num > random1)
        {
            MessageBox.Show("Too high");
        }
        else
        {
            MessageBox.Show("Congratulations");
        }
    }
