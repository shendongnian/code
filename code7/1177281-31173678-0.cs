    In "frmStudentRegistration":
    public frmStudentDetailsForm StudentDetailsForm { get; set; }
    public void main ()
    {
        var studentRegistration = new frmStudentRegistration();
        var studentDetailsForm = new frmStudentDetailsForm();
        studentRegistration.StudentDetailsForm = studentDetailsForm;
        studentRegistration.Show();
    }
    In "frmStudentRegistration":
    private void btnAdd_Click(object sender, EventArgs e)
    {
       StudentDetailsForm.AddRecord(txtStudentID.Text, txtStName.Text);
       StudentDetailsForm.ShowDialog();
    }
