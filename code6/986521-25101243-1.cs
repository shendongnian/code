        private void SearchBy_TextChanged(object sender, EventArgs e)
        {
            SQLCmdSet Database = new SQLCmdSet();
            string Param = "";
            if (this.ByName.Checked)
            {
                Param = "ClientName";
            }
            if (this.ByPostCode.Checked)
            {
                Param = "PostCode";
            }
            this.ClientInfor.DataSource = Database.ClientSearch(this.SearchBy.Text,Param);
             
        }
