    private void btnSave_Click(object sender, EventArgs e)
    {
           
            bool test =true ;
        ClearError (); // for clear all mark error in all conrols in the form
         test=   ValidateControle(cmbCaseCrime, 1);
          test=  ValidateControle(cmbMember, 1);
          test=  ValidateControle(cmbCaseType, 1);
           test= ValidateControle(txtCaseHasr, 1);
          test=  ValidateControle(txtCaseNum, 1);
    
            if (test ==false )
            {
                MessageBox .Show("You have some error !");
            return;
            }
    
        string str = btnSave.Text;
        switch (str)
        {
            case "add":
    
                DataTable dt = new DataTable();
                dt = cs.Verify_CASES(txtCaseNum.Text, txtCaseYear.Text, Convert.ToInt32(cmbCaseType.SelectedValue), Convert.ToInt32(cmbCaseRegion.SelectedValue));
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("already added ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    ce.ADD_CASE(txtCaseNum.Text, txtCaseHasr.Text, dtp_CaseComingDate.Value, txtCaseYear.Text,
                            Convert.ToInt32(cmbCaseType.SelectedValue),
                            Convert.ToInt32(cmbCaseRegion.SelectedValue),
                            Convert.ToInt32(cmbCaseStatus.SelectedValue),
                            Convert.ToInt32(cmbCaseCrime.SelectedValue),
                            Convert.ToInt32(cmbMember.SelectedValue), txtCaseStatusDate.Text);
    
    
    
                    MessageBox.Show("added successfuly", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
    
                    this.txtidCase.Text = ce.GET_LAST_CASE_ID().Rows[0][0].ToString();
    
                    this.btnAddRemain.Enabled = true;
                    this.cmbCaseRemain.Focus();
                    this.btnSave.Enabled = false;
    
    
                }
