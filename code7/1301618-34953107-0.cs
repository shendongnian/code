    public void button1_Click_1(object sender, EventArgs e) //2CookiesPerClick
    {
       MessageBox.Show("Checking...")
       
       if (cookies > 9)
       {
           panel1.Hide();
           cookies -= 10;
           MessageBox.Show("You bought 2 Cookies per Click!");
       }
       if (cookies <= 9)
       {
           button1.Show();
           label2.Show();
           MessageBox.Show("You don't have enough cookies to buy this upgrade!");
       }
    }
