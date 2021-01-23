    public static string GetSumMul(this string input, double num1, double num2)
        {
            var textBoxValue = Convert.ToDouble(input); // this might throw FormatException or OverflowException
            return ((textBoxValue*num1) + num2).ToString();
        }
    
        public static string GetMul(this string input, double num1)
        {
            var textBoxValue = Convert.ToDouble(input); // this might throw FormatException or OverflowException
            return (textBoxValue * num1).ToString();
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            double costPerHour = 3.00;
            double costOfInsurance = 1.00;
            try
            {
                if (chbInsurance.Checked == true)
                    txtCost.Text = txtHours.Text.GetSumMul( costPerHour ,costOfInsurance);
                else
                    txtCost.Text = txtHours.Text.GetMul( costPerHour);
            }
            catch (FormatException)
            {
                //"Unable to convert txtCost.Text to a Double."
            }
            catch (OverflowException)
            {
                //" txtCost.Text is outside the range of a Double."
                
            }
            
        }
