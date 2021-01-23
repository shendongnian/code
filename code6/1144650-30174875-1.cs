    public bool IsOperator(TextBox textbox,string name)
        {
            if (textbox.Text== "+" || textbox.Text == "-" || textbox.Text == "*" || textbox.Text == "/")
            {
              return true;
            }
                MessageBox.Show(name + " Must be +, -, *, or /.", "Entry Error");
                txtOperator1.Focus();
                return false;            
        }
