        cs.Open();
        SqlCommand cmd = new SqlCommand("SELECT ApplicantUsername, Branch, DescriptionOfHouse, DescritpionOfHouseType, LivingCondition, MembersOfHousehold, RealProperty, PersonalProperty, Collaterals, PurposeOfLoan, LoanDesired, MaxLoanVal, PromisoryNoteVal, MonthlyInstallment1, Terms, TotalMonthlyIncome, TotalMonthlyExpenses, Class, NarrativeReport FROM CustomerCreditReport WHERE ApplicantUsername = '" + uname + "'", cs);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            txtUsername.Text = reader["ApplicantUsername"].ToString();
            txtBranch.Text = reader["Branch"].ToString();
            txtDesc.Text = reader["DescriptionOfHouse"].ToString();
            txtOAR.Text = reader["DescritpionOfHouseType"].ToString();
            txtCond.Text = reader["LivingCondition"].ToString();
            txtMem.Text = reader["MembersOfHousehold"].ToString();
            txtReal.Text = reader["RealProperty"].ToString();
            txtPersonal.Text = reader["PersonalProperty"].ToString();
            txtCollateral.Text = reader["Collaterals"].ToString();
            txtPurpose.Text = reader["PurposeOfLoan"].ToString();
            txtDesired.Text = reader["LoanDesired"].ToString();
            txtMLV.Text = reader["MaxLoanVal"].ToString();
            txtPNV.Text = reader["PromisoryNoteVal"].ToString();
            txtMI.Text = reader["MonthlyInstallment1"].ToString();
            txtTerms.Text = reader["Terms"].ToString();
            txtTotIncome.Text = reader["TotalMonthlyIncome"].ToString();
            txtTotExpenses.Text = reader["TotalMonthlyExpenses"].ToString();
            txtClass.Text = reader["Class"].ToString();
            txtNarrative.Text = reader["NarrativeReport"].ToString();
        }
        cs.Close();
