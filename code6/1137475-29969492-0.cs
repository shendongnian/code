        private async void ReadDatabase()
        {
            string errorMSG01 = "...";
            string errorMSG02 = "...";
            string captionMSG = "...
            string BackupPath = txtBakPath.Text;
            string ServerName = txtSqlServer.Text;
            string SQLinstance = cmbSqlInst.SelectedItem.ToString();
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            if (String.IsNullOrEmpty(txtBakPath.Text))
            {
                System.Windows.Forms.MessageBox.Show(errorMSG01, captionMSG, buttons, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else if (!Directory.Exists(BackupPath))
            {
                System.Windows.Forms.MessageBox.Show(errorMSG02, captionMSG, buttons, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else
            {
                string connetionString = null;
                SqlConnection connection;
                SqlCommand command;
                string sql = null;
                SqlDataReader dataReader;
                connetionString = ("Data Source=DPC-OHEINRICH\\NETZWERKLABOR; Integrated Security=True;");
                sql = "Select * from Sys.Databases";
                connection = new SqlConnection(connetionString);
                try
                {
                    connection.Open();
                    command = new SqlCommand(sql, connection);
                    dataReader = command.ExecuteReader();
                    StatusPrinter(0x0003, null);
                    CreateLogfile(BackupPath);
                    DeleteOldBakFiles();
                    while (dataReader.Read())
                    {
                        string db_name = Convert.ToString(dataReader.GetValue(0));
                        Task backupTask = Task.Run(() => BackupProcess(ServerName, SQLinstance, BackupPath, db_name));
                    }
                    dataReader.Close();
                    command.Dispose();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    lblStatusMessage.Content = Convert.ToString(ex.Message);
                }
            }
        }
        private void BackupProcess(string ServerName, string SQLinstance, string BackupPath, string db_name)
        {
            DateTime today = DateTime.Now;
            string todayformat = string.Format("{0:G}", today);
            string BakFileDate = todayformat.Replace(".", "").Replace(" ", "").Replace(":", "");
            string ReportBakFile = BackupPath + "\\" + db_name + "_db_" + BakFileDate + @".bak'";
            if (db_name != "tempdb")
            {
                string connetionString = null;
                SqlConnection connection;
                SqlCommand command;
                string sql = null;
                SqlDataReader dataReader;
                connetionString = ("Data Source="+ServerName+"\\"+SQLinstance+"; Integrated Security=True;");
                sql = @"BACKUP DATABASE " + db_name + @" TO DISK = '" + BackupPath + "\\" + db_name + "_db_" + BakFileDate + @".bak'";
                connection = new SqlConnection(connetionString);
                try
                {
                    connection.Open();
                    command = new SqlCommand(sql, connection);
                    dataReader = command.ExecuteReader();
                    dataReader.Close();
                    command.Dispose();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                this.Dispatcher.Invoke(new Action(() => this.WriteLogile(1, ReportBakFile)));
                this.Dispatcher.Invoke(new Action(() => this.StatusPrinter(0x0004, db_name)));
            }
        }
        public void DoSomething()
        {
            //we are done...
        }
