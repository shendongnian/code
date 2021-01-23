    private void button1_Click(object sender, EventArgs e) {
      // double as the most general numeric type
      double num1, num2;
    
      if (!double.TryParse(textBox1.Text, out num1)) {
        if (textBox1.CanFocus) 
          textBox1.Focus();
    
        MessageBox.Show(String.Format("\"{0}\" is not a valid value", textBox1.Text));
      } 
      else if (!double.TryParse(textBox2.Text, out num2)) {
        if (textBox2.CanFocus) 
          textBox2.Focus();
    
        MessageBox.Show(String.Format("\"{0}\" is not a valid value", textBox2.Text));
      }
      else
        textBox3.Text = (num1 * num2).ToString();
    }
