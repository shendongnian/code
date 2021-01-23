    public void Button_Click(object sender, RoutedEventArgs e) //random
    {
        Random chiffrealeatoire = new Random();
        int random1 = (chiffrealeatoire.Next(0, 20));
        if (BoiteChiffre.Text < random1)
        {
            MessageBox.Show("Too low");
        }
        if (BoiteChiffre.Text > random1)
        {
            MessageBox.Show("Too high");
        }
        else
        {
            MessageBox.Show("Congratulations");          
        }
    }
       
