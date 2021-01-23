    private decimal Calculate()
    {
         // This array is to hold the logical operators
         string[] allowed = { "+", "-", "*", "/" };
         decimal result = 0m;
         // If the right operator is selected then perform the action and return result
         if (operate.Text == "+")
         {
              result = Convert.ToDecimal(operand1.Text) + Convert.ToDecimal(operand2.Text);                
         }
         else if (operate.Text == "-")
         {
              result = Convert.ToDecimal(operand1.Text) - Convert.ToDecimal(operand2.Text);
          }
          else if (operate.Text == "*")
          {
              result = Convert.ToDecimal(operand1.Text) * Convert.ToDecimal(operand2.Text);
          }
          else if (operate.Text == "/")
          {
              result  = (Convert.ToDecimal(operand1.Text) / Convert.ToDecimal(operand2.Text));             
          }
          // if the operator is not something within the array then display message
          else if (!allowed.Contains(operate.Text))
          {
              string msg = string.Format("Not a valid operater {0}Please Enter one of the Following:{0}{1}"
            , Environment.NewLine, string.Join(Environment.NewLine, allowed));
            
              MessageBox.Show(msg);
              
              operate.Text = "";
             
          }
            
        return result;
           
    }
