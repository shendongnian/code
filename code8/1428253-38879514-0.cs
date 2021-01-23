    private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
          Regex r = new Regex(@"^(Y|N){1}$");
          if (r.IsMatch(textBox1.Text)==false) {
              //do something, like popping an alert or making e.Handled = true to cancel the event.
          }
        }
