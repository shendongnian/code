    private void addInterestButton_Click(object sender, EventArgs e)
    {
        double interestRate = double.Parse(interestUpDown.Text); //this is local variable!!
        CalculateInterest();
        this.Close();
    }
