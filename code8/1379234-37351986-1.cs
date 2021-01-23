    private void btnCalculate_Click (object sender, EventArgs e)
    {
        int FirstPrice, SecondPrice, ThirdPrice, FourthPrice;
        int FirstQnty, SecondQnty, ThirdQnty, FourthQnty;
        int answer = 0; 
    
        try
        {
            FirstPrice = (int)TextBox1.Text.Replace("£", "");
            SecondPrice = (int)TextBox2.Text;
            ThirdPrice = (int)TextBox3.Text.Replace("£", "");
            FourthPrice = (int)TextBox4.Text;
            FirstQty = (int)TextBox5.Text.Replace("£", "");
            SecondQty = (int)TextBox6.Text;
            ThirdQty = (int)TextBox7.Text.Replace("£", "");
            FourthQty = (int)TextBox8.Text;
    
            answer = FirstPrice * FirstQty;
            answer += SecondPrice * SecondQty;
            answer += ThirdPrice * ThirdQty;
            answer += FourthPrice * FourthQty;
    
            MessageBox.Show("Your total is £" + answer.ToString());
        }
        catch (FormatException)
        {
            MessageBox.Show("Please enter a decimal value");
        }
        }
 
