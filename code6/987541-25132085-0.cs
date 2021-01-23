    if (!string.IsNullOrEmpty(txtSalaryRange.Text))
    {
       newjob.SalaryRange = txtSalaryRange.Text;
    }
    else
    {
       newjob.SalaryRange = "00000";
    }
