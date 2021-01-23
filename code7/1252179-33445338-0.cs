    // Display Student Details Form
    public void displayStudent()
    {
        StudentDetails sd = new StudentDetails();
        sd.getData(x);
        displayUserName.Text = sd.getUserName();
        sd.ShowDialog();
    }
