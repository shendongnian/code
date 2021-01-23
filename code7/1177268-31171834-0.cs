     private void button2_Click(object sender, EventArgs e)
        {
            int magicnumber;
            if(int.TryParse(textBox2.Text,out magicnumber))
            {
                MessageBox.Show ("Your number is " + magicnumber);                              
            }
            else
            {
                MessageBox.Show("Failure");
            }
        }
