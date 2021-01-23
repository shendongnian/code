        private static int loginAttempts = 0;
        private void button2_Click(object sender, EventArgs e)
        {
           if (textBox1.Text == "hvelreki")
              MessageBox.Show("Ласкаво просимо!");
           if (textBox2.Text == "sigurros")
              MessageBox.Show("Ласкаво просимо");
           else{
              loginAttemps++;
              if(loginAttempts >= 3)
                  Application.exit();
           }
    }
