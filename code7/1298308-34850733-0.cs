    status = textBox1.Text;
    allocated = textBox2.Text;
    
    BindingSource bs = new BindingSource();
    bs.DataSource = customerDataGridView.DataSource;
    
    if (!string.IsNullOrEmpty(status) && !string.IsNullOrEmpty(allocated))
    	bs.Filter = "[Status] LIKE '%" + status + "%' AND [AssignedTo] LIKE '%" + allocated + "%'"; // both filter assign.
    else if (string.IsNullOrEmpty(status))
    	bs.Filter = "[AssignedTo] LIKE '%" + allocated + "%'"; // only allocated filter assign.
    else //(string.IsNullOrEmpty(allocated))
    	bs.Filter = "[Status] LIKE '%" + status + "%'"; // only status filter assign.
    				
    customerDataGridView.DataSource = bs;
