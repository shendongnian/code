    public bool IsOperator(TextBox textbox, string name)
        {
            if (name == "+" || name == "-" || name == "*" || name == "/")
            {
              return true;
            }
                MessageBox.Show(name + " Must be +, -, *, or /.", "Entry Error");
                txtOperator1.Focus();
                return false;            
        }
