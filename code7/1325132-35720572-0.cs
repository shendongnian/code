    private void DisplayNumbers(int number)
    {
        txtCCode1.Enabled = (number <= 1);
        txtCCode2.Enabled = (number <= 2);
        txtCCode3.Enabled = (number <= 3);
        txtCCode4.Enabled = (number <= 4);
        txtCCode5.Enabled = (number <= 5);
        txtCCode6.Enabled = (number <= 6);
        txtGrade1.Enabled = (number <= 1);
        // ....
    }
