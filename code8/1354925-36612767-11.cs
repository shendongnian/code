    private void addInterestButton_Click(object sender, EventArgs e)
    {
        interestRate = double.Parse(interestUpDown.Text); //remove the double
        CalculateInterest();
        this.Close();
    }
