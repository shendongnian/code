    private void Button_Click_2(object sender, RoutedEventArgs e) //veri
    {
        int num;
        if (!int.TryParse(BoiteChiffre.Text, out num))
        {
            MessageBox.Show("Must enter an integer");
        }
        else if (num < random1)
        {
            MessageBox.Show("Too low");
        }
        else if (num > random1)
        {
            MessageBox.Show("Too high");
        }
        else
        {
            MessageBox.Show("Congratulations");
        }
    }
