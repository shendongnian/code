    public string compute1(double n1, double n2, string opr)
    {
       var ans = "";
       if (opr == "-")
       {
          ans = (n1 - n2).ToString();
       }
       return ans; 
    }
    
    private void cmbOperator_SelectedIndexChanged(object sender, EventArgs e)
    {
       double var1 = Convert.ToDouble(txtFirstOperand.Text);
       double var2 = Convert.ToDouble(txtSecondOperand.Text);
    
       if (cmbOperator.Text == "+" || cmbOperator.Text == "-")
       {
          txtResult.Text = compute1(var1, var2, opr1); //Heres the Error i want to show the answer in the box
       }
    }
