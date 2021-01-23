            ArrayList fields = new ArrayList();
            fields.Add("id");
            if (CDomain.Checked)    { fields.Add(", domain"); }
            if (CCPU.Checked)       { fields.Add(", cpu_speed"); }
            if (CIP.Checked)        { fields.Add(", pc_ip"); }
            if (CLastUser.Checked)  { fields.Add(", last_user"); }
            if (CLoginDate.Checked) { fields.Add(", last_logon"); }
            if (CUsers.Checked)     { fields.Add(", users"); }
            if (CMonitors.Checked)  { fields.Add(", monitors"); }
            if (CPrinters.Checked)  { fields.Add(", printers"); }
            if (CPCName.Checked)    { fields.Add(", pc_name"); }
            if (COS.Checked)        { fields.Add(", os"); }
            if (CBit.Checked)       { fields.Add(", bitversion"); }
            if (CPrograms.Checked)  { fields.Add(", programs"); }
            if (CLicense.Checked)   { fields.Add(", license_key"); }
            if (CCPU.Checked)       { fields.Add(", cpu_speed"); }
            if (CRAM.Checked)       { fields.Add(", ram"); }
            if (CAdapter.Checked)   { fields.Add(", adapter_speed"); }
            if (CHardDrives.Checked){ fields.Add(", drives"); }
            dataBase db = new dataBase();
            try
            {                
                ArrayList v = db.queryDB(query, fields);
                if (v.ToArray().Length == 0)
                {
                    MessageBox.Show("No results.");
                }
            }
            catch (Exception er) { MessageBox.Show("Somethign went wrong in the search function. " + er.ToString()); }
            ReportViewer report = new ReportViewer();
            report.Show();
            this.Close();
