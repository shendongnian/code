    public void ExtractDB()
            {
    			var szSqliteFilename = "databasename.db3";
    			var szSourcePath = new FileManager().GetLocalFilePath(szSqliteFilename);
    
    			var szDatabaseBackupPath = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + "/databasename_Backup.db3";
    			if (File.Exists(szSourcePath))
    			{
    				File.Copy(szSourcePath, szDatabaseBackupPath, true);
    				Toast.MakeText(this, "Copied", ToastLength.Short).Show();
    			}
            }
