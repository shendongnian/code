    using (var destination = new System.Data.SQLite.SQLiteConnection(string.Format("Data Source={0}\\DriversTrucksBackup.db; Version=3;", this.txtLocation.Text)))
                        {
                            da.cn.Open();
                            destination.Open();
                            da.cn.BackupDatabase(destination, "main", "main", -1, null, 0);
                            da.cn.Close();
                        }
