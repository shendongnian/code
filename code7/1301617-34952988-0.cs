        MessageBox.Show("Checking...");
        for (int attempt = 0; attempt < 10; attempt++)
        {
            cookies++;
            if (cookies >= 10)
            {
                panel1.Hide();
                cookies -= 10;
                MessageBox.Show("You bought 2 Cookies per Click!");
            }
            else
            {
                button1.Show();
                label2.Show();
                MessageBox.Show("You don't have enough cookies to buy this upgrade!");
            }
        }
