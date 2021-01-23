    SqlConnection objcon = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|Database1.mdf;Integrated Security=True;");
        SqlCommand sqlcmd = new SqlCommand();
        protected void btnBackup_Click(object sender, EventArgs e)
        {
            try
            {
                string _DatabaseName = ddlDatabases.SelectedItem.Text.ToString();
                string cleandb=Path.GetFileNameWithoutExtension(_DatabaseName);
                string _BackupName = cleandb + "_" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString() + ".bak";
                objcon.Open();
                string sqlQuery = "BACKUP DATABASE [" + _DatabaseName + "] TO DISK='C:\\SQLServerBackups\\" + _BackupName + "'";
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, objcon);
                sqlCommand.CommandType = CommandType.Text;
                int iRows = sqlCommand.ExecuteNonQuery();
                objcon.Close();
                lblMessage.Text = "The " + _DatabaseName + " database Backup with the name " + _BackupName + " successfully...";
                ReadBackupFiles();
            }
            catch (SqlException sqlException)
            {
                lblMessage.Text = sqlException.Message.ToString();
            }
            catch (Exception exception)
            {
                lblMessage.Text = exception.Message.ToString();
            }
        }
