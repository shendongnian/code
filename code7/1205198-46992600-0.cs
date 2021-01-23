        private void btnAdd_Click(object sender, EventArgs e)
        {
            int firstNumber, secondNumber;
            if (!int.TryParse(txtBxFirstNumber.Text, out firstNumber) || firstNumber < 1)
            {
                lblResults.Text = "First number needs\n to be numeric and > 0";
                lblResults.ForeColor = Color.Red;
                lblResults.Visible = true;
                txtBxFirstNumber.Clear();
                return;
            }
            if (!int.TryParse(txtBxSecondNumber.Text, out secondNumber) || secondNumber < 1)
            {
                lblResults.Text = "Second number need\n to be numeric and > 0";
                lblResults.ForeColor = Color.Red;
                lblResults.Visible = true;
                txtBxSecondNumber.Clear();
                return;
            }
            lblResults.ForeColor = Color.Yellow;
            lblResults.Visible = true;
            lblResults.Text = Convert.ToString(firstNumber + secondNumber);
        }
        private void btnMultiply_Click(object sender, EventArgs e)
        {
            int firstNumber, secondNumber;
            if (!int.TryParse(txtBxFirstNumber.Text, out firstNumber) || firstNumber < 1)
            {
                lblResults.Text = "First number needs\n to be numeric";
                lblResults.ForeColor = Color.Red;
                lblResults.Visible = true;
                txtBxFirstNumber.Clear();
                return;
            }
            if (!int.TryParse(txtBxSecondNumber.Text, out secondNumber) && secondNumber < 1)
            {
                lblResults.Text = "Second number need\n to be numeric";
                lblResults.ForeColor = Color.Red;
                lblResults.Visible = true;
                txtBxSecondNumber.Clear();
                return;
            }
            lblResults.ForeColor = Color.Yellow;
            lblResults.Visible = true;
            lblResults.Text = Convert.ToString(firstNumber * secondNumber);
        }
