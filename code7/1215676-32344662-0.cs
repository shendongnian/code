    private void btnSubmit_Click(object sender, EventArgs e)
    {
        string name = txtName.Text;
        string address = txtAddress.Text;
        var rows = dt.Select(string.Format("NAME = '{0}' AND ADDRESS = '{1}'", name, address));
        if (rows.Length == 0)
        {
            DataRow dr1 = dt.NewRow();
            dr1[0] = name;
            dr1[1] = address;
            dt.Rows.Add(dr1);
        }    
        else
            MessageBox.Show("Some message.");        
    }
