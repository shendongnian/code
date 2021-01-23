      private void button1_Click(object sender, EventArgs e)
      {
        float num1, num2, res;
        try
              {
                 num1 = float.Parse(textBox1.Text);
              }
            catch (Exception)
              {
                 MessageBox.Show("Error");       
              }
            try
              {
                 num2 = float.Parse(textBox2.Text);
              }
            catch (Exception)
              {
                 MessageBox.Show("Error");      
              }
        res = num1 * num2;
        textBox3.Text = (num1 * num2).ToString();
      }
    
