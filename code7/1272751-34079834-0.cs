        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ptype = cboType.Text.ToString().Trim();
            //change query according to your db
            string sql = string.Format(@"select productid from yourtable where producttype = '{0}'", ptype);
            Connect con = new Connect();//you should learn ExecuteScalar method
            DataTable dt = con.executeSelect(sql);
            object id = dt.Rows[0][0];//assume data in db is consistent, 
            this.lblID.Text = id.ToString();
        }
