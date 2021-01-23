    int n = 0;
    DataTable dt;
    if (this.dgv_CaseRemain.CurrentRow.Cells[1].Value != null)
    {
    	if (int.TryParse(this.dgv_CaseRemain.CurrentRow.Cells[1].Value.ToString(), out n))
    	{
    		dt = ce.FILTER_CMB_CASEREMAIN(n);
    	}
    }
    if (dt!=null && dt.Rows.Count > 0)
    {
    
    	cmbCaseRemain.DisplayMember = "caseRemain";
    	cmbCaseRemain.ValueMember = "idCaseRemain";
    	cmbCaseRemain.DataSource = dt;
    }
