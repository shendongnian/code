    public void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Dentist> dentistList = new List<Dentist>();
            Dentist dent = new Dentist();
    
    
           if (comboBox1.SelectedValue = dent.Name)
            {
                txtDName.Text = dent.Name.ToString();
                txtDSurname.Text = dent.Surname;
                txtDDOB.Text = dent.DOB.ToString();
                txtGender.Text = dent.Gender;
                txtSalary.Text = dent.Salary.ToString();
    
            }
    
    
        }
