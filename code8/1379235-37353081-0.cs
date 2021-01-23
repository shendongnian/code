            bool isNumeric = true;
            double answer = 0; 
            double firstTextBoxNumber = 0;
            double thirdTextBoxNumber = 0;
            double fifthTextBoxNumber = 0;
            double seventhTextBoxNumber = 0;
            int secondTextBoxNumber = 0;
            int fourthTextBoxNumber = 0;
            int sixTextBoxNumber = 0;
            int eightTextBoxNumber = 0;
            try
            {
                if (String.IsNullOrWhiteSpace(tbFirstNumber.Text) || String.IsNullOrWhiteSpace(tbSecondNumber.Text) || String.IsNullOrWhiteSpace(tbThirdNumber.Text) || String.IsNullOrWhiteSpace(tbFourthNumber.Text) || String.IsNullOrWhiteSpace(tbFifthNumber.Text) || String.IsNullOrWhiteSpace(tbSixNumber.Text) || String.IsNullOrWhiteSpace(tbSeventhNumber.Text) || String.IsNullOrWhiteSpace(tbEightNumber.Text))
                {
                    isNumeric = false;
                }
                else
                {
                    //Check if "Prices" are all Doubles
                    if (isNumeric)
                    {
                        isNumeric = double.TryParse(tbFirstNumber.Text.Replace("£", ""), out firstTextBoxNumber);
                    }
                    if (isNumeric)
                    {
                        isNumeric = double.TryParse(tbThirdNumber.Text.Replace("£", ""), out thirdTextBoxNumber);
                    }
                    if (isNumeric)
                    {
                        isNumeric = double.TryParse(tbFifthNumber.Text.Replace("£", ""), out fifthTextBoxNumber);
                    }
                    if (isNumeric)
                    {
                        isNumeric = double.TryParse(tbSeventhNumber.Text.Replace("£", ""), out seventhTextBoxNumber);
                    }
                    //Check if "Quanity" are all Integers
                    if (isNumeric)
                    {
                        isNumeric = int.TryParse(tbSecondNumber.Text, out secondTextBoxNumber);
                    }
                    if (isNumeric)
                    {
                        isNumeric = int.TryParse(tbFourthNumber.Text, out fourthTextBoxNumber);
                    }
                    if (isNumeric)
                    {
                        isNumeric = int.TryParse(tbSixNumber.Text, out sixTextBoxNumber);
                    }
                    if (isNumeric)
                    {
                        isNumeric = int.TryParse(tbEightNumber.Text, out eightTextBoxNumber);
                    }
                }
                if (isNumeric)
                {
                    answer = firstTextBoxNumber * secondTextBoxNumber;
                    answer += thirdTextBoxNumber * fourthTextBoxNumber;
                    answer += fifthTextBoxNumber * sixTextBoxNumber;
                    answer += seventhTextBoxNumber * eightTextBoxNumber;
                    MessageBox.Show("Your total is £" + answer.ToString());
                }
                else
                {
                    MessageBox.Show("Please enter a decimal value");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
