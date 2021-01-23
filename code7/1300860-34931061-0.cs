    Form2 form2 = new Form2();    
    
    private void Klik_Click(object sender, EventArgs e)
        {
          counter++;
          if(counter==1)
          {
            Button1.BackColor = Color.Red;
            Button2.BackColor = Color.Red;
            Button3.BackColor = Color.Red;
            form2.ButtonColor = Color.Red;
          }
          if (counter > 1)
          {
            Button1.BackColor = Color.Green;
            Button2.BackColor = Color.Green;
            Button3.BackColor = Color.Green;
            form2.ButtonColor = Color.Green;
            counter = 0;
          }
            form2.Show();
            form2.Refresh();
        }
