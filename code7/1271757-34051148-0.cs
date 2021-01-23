    private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable result = LoginDB.Login(txtUID.Text, txtpwd.Text);
                if (result.Rows.Count == 1)
                {
                    if (rbtnStud.Checked)
                    {
                        // pass the name to the students form
                        Students form = new Students(dt.Rows[0]["Name"] as string);
                        form.ShowDialog();
                        this.Hide();
                    } 
                 else if{}
    ....
