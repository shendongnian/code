     private void OnSomeUIEvent()
        {
            //In UI thread
            var ipRows = new Dictionary<string, DataGridViewRow>();
            var targetUser = ""; //tbTargetUser.Text
            var pwd = ""; //NewPassword
            var basePassword = ""; //Some value
           
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                var ipAddress = row.Cells["cIPAddress"].Value.ToString();
                
                if (!row.IsNewRow && ipAddress.Contains("Invalid") == false)
                {
                    ipRows.Add(ipAddress, row);
                }
            }
            Task.Factory.StartNew(() => {
                ChangePassword(ipRows, targetUser, pwd, basePassword);
            }).ContinueWith(t => { 
               //Do Something when task completed
            });
        }
        private void ChangePassword(Dictionary<string, DataGridViewRow> ipRows, string targetUser, string newPwd, string basePwd)
        {  //in background thread
            foreach (var ipRow in ipRows)
            {
                var pwd = newPwd;
                var basePassword = basePwd;
                var appendNumber = 0;
                var increaseNumber = 1; //some number
                if (pspasswrd(ipRow.Key, targetUser, pwd).Contains("Password successfully changed"))
                {
                    dgvResults.Invoke((MethodInvoker)(() =>
                    {
                        dgvResults.Rows.Add(ipRow.Key, targetUser, pwd);
                    }));
                    
                    appendNumber = appendNumber + increaseNumber;
                    pwd = basePassword + increaseNumber;
                }
                else
                {
                    dgvData.Invoke((MethodInvoker)(() =>
                    {
                        ipRow.Value.DefaultCellStyle.BackColor = Color.Red;
                    }));
                }
            }
        }
